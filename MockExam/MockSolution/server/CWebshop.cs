using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    class CWebshop : IWebshop, IBackoffice
    {
        private readonly string name;
        private readonly List<Item> stock;
        private List<Order> orders;
        private int orderIdGenerator = 1;

        private List<IWebshopCallback> clients;

        private CWebshop()
        {
            name = "Peter's Bookshop";
            stock = new List<Item>
            {
                new Item() { ProductId = "Dracula", ProductInfo = "Very Scary Story", Price = 10.50, Stock = 5, OnSale = false },
                new Item() { ProductId = "Don Quixote", ProductInfo = "Spanish Classic", Price = 15.00, Stock = 9, OnSale = false },
                new Item() { ProductId = "Ali Baba", ProductInfo = "Arab Fairy Tale", Price = 12.50, Stock = 54, OnSale = true }
            };
            orders = new List<Order>();
            clients = new List<IWebshopCallback>();
        }

        private bool AddClient(IWebshopCallback client)
        {
            if (!ClientExists(client))
            {
                clients.Add(client);
                Console.WriteLine("Added new client!");
                return true;
            }
            return false;
        }

        private bool ClientExists(IWebshopCallback client)
        {
            bool found = false;
            int counter = 0;
            while (counter < clients.Count && !found)
            {
                IWebshopCallback current = clients.ElementAt(counter++);
                found = current == client;
            }
            return found;
        }

        private void ShowStatus(string message)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(FormatTime(now) + " : " + message);
        }

        private string FormatTime(DateTime t)
        {
            string s = t.ToString("HH") + "h";
            s += t.ToString("mm") + "m";
            s += t.ToString("ss") + "s";
            return s;
        }
        
        public string GetWebshopName()
        {
            ShowStatus("GetWebshopName() was called.");
            return name;
        }

        public List<Item> GetProductList()
        {
            ShowStatus("GetProductList() was called.");
            return stock;
        }

        public string GetProductInfo(string productId)
        {
            ShowStatus("GetProductInfo(" + productId + ") was called.");
            foreach (Item item in stock)
            {
                if (item.ProductId == productId) return item.ProductInfo;
            }
            return "";
        }

        public bool BuyProduct(string ProductId)
        {
            ShowStatus("BuyProduct(" + ProductId + ") was called.");
            foreach (Item item in stock)
            {
                if (item.ProductId == ProductId && item.Stock > 0)
                {
                    Order newOrder = new Order();
                    newOrder.OrderId = orderIdGenerator++;
                    newOrder.ProductId = ProductId;
                    newOrder.Moment = DateTime.Now;
                    orders.Add(newOrder);
                    item.Stock--;
                    NotifyProductSold(OperationContext.Current.GetCallbackChannel<IWebshopCallback>());
                    return true;
                }
            }
            return false;
        }

        private void NotifyProductSold( IWebshopCallback toClient)
        {
            foreach (IWebshopCallback c in clients)
            {
                if (c != toClient)
                {
                    c.UpdateStock(this.stock);
                }
            }
        }

        public List<Order> GetOrderList()
        {
            ShowStatus("GetOrderList() was called.");
            return orders;
        }


        public void RegisterStockUpdate()
        {
            IWebshopCallback client = OperationContext.Current.GetCallbackChannel<IWebshopCallback>();
            AddClient(client);
        }
    }
}
