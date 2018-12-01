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
        string Name;
        List<Item> Stock;
        List<Order> Orders;
        private int orderIdGenerator = 1;

        List<IWebshopCallback> clients;

        CWebshop()
        {
            Name = "Peter's Bookshop";
            Stock = new List<Item>();
            Stock.Add(new Item() { ProductId = "Dracula",     ProductInfo = "Very Scary Story", Price = 10.50, Stock = 5, OnSale = false });
            Stock.Add(new Item() { ProductId = "Don Quixote", ProductInfo = "Spanish Classic", Price = 15.00, Stock = 9, OnSale = false });
            Stock.Add(new Item() { ProductId = "Ali Baba",    ProductInfo = "Arab Fairy Tale", Price = 12.50, Stock = 54, OnSale = true });
            Orders = new List<Order>();
            clients = new List<IWebshopCallback>();
        }

        private bool addClient(IWebshopCallback client)
        {
            if (!clientExists(client))
            {
                clients.Add(client);
                Console.WriteLine("Added new client!");
                return true;
            }
            return false;
        }

        private bool clientExists(IWebshopCallback client)
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

        private void showStatus(string message)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(formatTime(now) + " : " + message);
        }

        private string formatTime(DateTime t)
        {
            string s = t.ToString("HH") + "h";
            s += t.ToString("mm") + "m";
            s += t.ToString("ss") + "s";
            return s;
        }
        
        public string GetWebshopName()
        {
            showStatus("GetWebshopName() was called.");
            return Name;
        }

        public List<Item> GetProductList()
        {
            showStatus("GetProductList() was called.");
            return Stock;
        }

        public string GetProductInfo(string productId)
        {
            showStatus("GetProductInfo(" + productId + ") was called.");
            foreach (Item item in Stock)
            {
                if (item.ProductId == productId) return item.ProductInfo;
            }
            return "";
        }

        public bool BuyProduct(string ProductId)
        {
            showStatus("BuyProduct(" + ProductId + ") was called.");
            foreach (Item item in Stock)
            {
                if (item.ProductId == ProductId && item.Stock > 0)
                {
                    Order newOrder = new Order();
                    newOrder.OrderId = orderIdGenerator++;
                    newOrder.ProductId = ProductId;
                    newOrder.Moment = DateTime.Now;
                    Orders.Add(newOrder);
                    item.Stock--;
                    notifyProductSold(OperationContext.Current.GetCallbackChannel<IWebshopCallback>());
                    return true;
                }
            }
            return false;
        }

        private void notifyProductSold( IWebshopCallback toClient)
        {
            foreach (IWebshopCallback c in clients)
            {
                if (c != toClient)
                {
                    c.updateStock(this.Stock);
                }
            }
        }

        public List<Order> GetOrderList()
        {
            showStatus("GetOrderList() was called.");
            return Orders;
        }


        public void RegisterStockUpdate()
        {
            IWebshopCallback client = OperationContext.Current.GetCallbackChannel<IWebshopCallback>();
            addClient(client);
        }
         }
}
