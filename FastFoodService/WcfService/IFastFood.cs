using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IFastFood
    {
        [OperationContract]
        int GetOrderNr();

        [OperationContract]
        List<Product> GetAvailableProducts();

        [OperationContract]
        string BuyProducts(int orderId, List<string> products);
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public double Price { get; private set; }
        public int Stock { get; set; }

        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}
