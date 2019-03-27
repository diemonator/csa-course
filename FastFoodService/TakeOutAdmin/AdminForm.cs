using System;
using System.ServiceModel;
using System.Windows.Forms;
using TakeOutAdmin.ServiceReference;

namespace TakeOutAdmin
{
    public partial class AdminForm : Form, IAdminCallback
    {
        private AdminClient proxy;
        
        public AdminForm()
        {
            InitializeComponent();
            proxy = new AdminClient(new InstanceContext(this));
            proxy.Connect();
        }

        private void BtGetOrders_Click(object sender, EventArgs e)
        {
            lbOrders.Items.Clear();
            int[] orders = proxy.GetOrders();
            for (int i = 0; i < orders.Length; i++)
            {
                lbOrders.Items.Add(orders[i]);
            }
        }

        private void BtDeliver_Click(object sender, EventArgs e)
        {
            string selectedItem = lbOrders.SelectedItem.ToString();
            int order = int.Parse(selectedItem);
            lbOrders.Items.Remove(order);
            proxy.OrderNrReady(order);
            tbOrderReady.Text = order.ToString();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            proxy.Disconnect();
        }

        public void NewOrder(int orderId)
        {
            lbOrders.Items.Add(orderId);
        }

        public void NotifyReadyOrder(int orderId)
        {
            lbOrders.Items.Remove(orderId);
            tbOrderReady.Text = orderId.ToString();
        }
    }
}
