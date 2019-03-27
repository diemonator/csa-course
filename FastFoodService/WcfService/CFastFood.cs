using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CFastFood : IFastFood, IAdmin
    {
        private readonly List<Product> products;
        private List<IAdminCallback> callbacks;
        private List<int> orderNrs;
        private static int orderNr;

        public CFastFood()
        {
            orderNr = 1;
            callbacks = new List<IAdminCallback>();
            orderNrs = new List<int>();
            products = new List<Product>()
            {
                new Product("Cola", 1, 1),
                new Product("Burger", 3, 2),
                new Product("Chips", 2, 3)
            };
        }

        public int GetOrderNr()
        {
            return orderNr++;
        }

        public List<Product> GetAvailableProducts()
        {
            return products.FindAll(p => p.Stock > 0);
        }

        public string BuyProducts(int orderId, List<string> products)
        {
            List<Product> requestedProducts = new List<Product>();
            foreach (string item in products)
            {
                Product p = this.products.Find(product => product.Name == item);
                if (p.Stock > 0) requestedProducts.Add(p);
                else return p.Name;
            }
            orderNrs.Add(orderId);
            if (callbacks.Count > 0) callbacks.ForEach(client => client.NewOrder(orderId));
            requestedProducts.ForEach(item => item.Stock--);
            return null;
        }

        public List<int> GetOrders()
        {
            return orderNrs;
        }

        public void OrderNrReady(int nr)
        {
            IAdminCallback client = OperationContext.Current.GetCallbackChannel<IAdminCallback>();
            foreach (IAdminCallback item in callbacks)
            {
                if (item != client) item.NotifyReadyOrder(nr);
            }
            orderNrs.Remove(nr);
        }

        public void Connect()
        {
            IAdminCallback client = OperationContext.Current.GetCallbackChannel<IAdminCallback>();
            if (!callbacks.Contains(client)) callbacks.Add(client);
        }

        public void Disconnect()
        {
            IAdminCallback client = OperationContext.Current.GetCallbackChannel<IAdminCallback>();
            callbacks.Remove(client);
        }
    }
}
