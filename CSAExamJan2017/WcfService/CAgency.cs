using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CAgency : IAgency, IAdministrator
    {
        private List<House> houses;
        private Action<string> myEvent;
        private List<IMyEvent> callbacks;

        public CAgency()
        {
            houses = new List<House>()
            {
                new House("Gosho 1", 2, 2500, "Emcho", new List<int>()),
                new House("Pesho 3", 5, 5000, "Tosho", new List<int>() { 2500, 3000, 8000 }),
                new House("Geer 16", 3, 7500, "Radoslav", new List<int>() { 8500, 9055 })
            };
            callbacks = new List<IMyEvent>();
            myEvent = delegate { };
        }

        public bool AddOffer(string address, int offer)
        {
            House house = FindHouse(address);
            if (house != null && GetAvailableHouses().Contains(house))
            {
                house.Offers.Add(offer);
                if (!GetAvailableHouses().Contains(house))
                { 
                    IMyEvent myEvent = OperationContext.Current.GetCallbackChannel<IMyEvent>();
                    foreach (IMyEvent callback in callbacks)
                    {
                        if (callback != myEvent) callback.Notify(house.Address);
                    }
                }
                return true;
            }
            return false;
        }

        public List<House> GetAvailableHouses()
        {
            List<House> availableHouses = new List<House>();
            foreach (House house in houses)
            {
                if (house.Offers.Count < house.Capacity) availableHouses.Add(house);
            }
            return availableHouses;
        }

        public int GetNumberOfOffers(string address)
        {
            return FindHouse(address).Offers.Count;
        }

        public int GetHousePrice(string address)
        {
            return FindHouse(address).Price;
        }

        private House FindHouse(string address)
        {
            return houses.Find(x => x.Address == address);
        }

        public void Subscribe()
        {
            IMyEvent myEvent = OperationContext.Current.GetCallbackChannel<IMyEvent>();
            if (!callbacks.Contains(myEvent))
            {
                callbacks.Add(myEvent);
                this.myEvent += myEvent.Notify;
            }
        }

        public void Unsubscribe()
        {
            IMyEvent myEvent = OperationContext.Current.GetCallbackChannel<IMyEvent>();
            this.myEvent -= myEvent.Notify;
        }

        public List<int> GetAllOffers(string address)
        {
            return FindHouse(address).Offers;
        }
    }
}
