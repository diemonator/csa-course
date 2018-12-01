using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Runtime.Serialization;

namespace server
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public string ProductId { get; set; }   //     part of the contract

        public string ProductInfo { get; set; } // NOT part of the contract

        [DataMember]
        public double Price { get; set; }       //     part of the contract

        [DataMember]
        public int Stock { get; set; }          //     part of the contract

        public bool OnSale { get; set; }        // NOT part of the contract
    }

    [ServiceContract(Namespace = "server", CallbackContract = typeof(IWebshopCallback))]
    public interface IWebshop
    {
        [OperationContract]
        string GetWebshopName();

        [OperationContract]
        List<Item> GetProductList();
        
        [OperationContract]
        string GetProductInfo(string productId);
        
        [OperationContract]
        bool BuyProduct(string ProductId);

        [OperationContract]
        void RegisterStockUpdate();
    }

    public interface IWebshopCallback
    {
        [OperationContract]
        void updateStock(List<Item> products);
    }
}
