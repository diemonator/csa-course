using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace server
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public string ProductId { get; set; }
        
        [DataMember]
        public DateTime Moment { get; set; }
    }

    [ServiceContract(Namespace = "server")]
    public interface IBackoffice
    {
        [OperationContract]
        List<Order> GetOrderList();

     }
}
