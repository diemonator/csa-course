using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IMyEvent))]
    public interface IAgency
    {
        [OperationContract]
        int GetHousePrice(string address);
        [OperationContract]
        int GetNumberOfOffers(string address);
        [OperationContract]
        List<House> GetAvailableHouses();
        [OperationContract]
        bool AddOffer(string address, int offer);
        [OperationContract(IsOneWay = true)]
        void Subscribe();
        [OperationContract(IsOneWay = true)]
        void Unsubscribe();
    }

    interface IMyEvent
    {
        [OperationContract(IsOneWay = true)]
        void Notify(string address);
    }

    [DataContract]
    public class House
    {
        [DataMember]
        public string Address { get; set; }
        public int Capacity { get; set; }
        [DataMember]
        public int Price { get; set; }
        public string SellerName { get; set; }
        public List<int> Offers { get; set; }

        public House(string address, int capacity, int price, string sellerName, List<int> offers)
        {
            Address = address;
            Capacity = capacity;
            Price = price;
            SellerName = sellerName;
            Offers = offers;
        }
    }
}
