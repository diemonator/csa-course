using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IAdminCallback))]
    interface IAdmin
    {
        [OperationContract]
        List<int> GetOrders();

        [OperationContract(IsOneWay = true)]
        void OrderNrReady(int nr);

        [OperationContract(IsOneWay = true)]
        void Connect();

        [OperationContract(IsOneWay = true)]
        void Disconnect();
    }

    interface IAdminCallback
    {
        [OperationContract(IsOneWay = true)]
        void NewOrder(int orderId);

        [OperationContract(IsOneWay = true)]
        void NotifyReadyOrder(int orderId);
    }
}
