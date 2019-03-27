using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using SelfOrderClient.ServiceReference;

namespace SelfOrderClient
{
    public partial class ClientForm : Form
    {
        private FastFoodClient proxy;

        public ClientForm()
        {
            InitializeComponent();
            proxy = new FastFoodClient();
        }

        private void BtGetOrderNo_Click(object sender, EventArgs e)
        {
            tbOrderNo.Text = proxy.GetOrderNr().ToString();
        }

        private void BtGetProducts_Click(object sender, EventArgs e)
        {
            lbProducts.Items.Clear();
            lbPrice.Items.Clear();
            List<Product> products = proxy.GetAvailableProducts();
            foreach (Product product in products)
            {
                lbProducts.Items.Add(product.Name);
                lbPrice.Items.Add(product.Price);
            }
        }

        private void BtOrder_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            foreach (string item in lbProducts.SelectedItems)
            {
                temp.Add(item);
            }
            string answer = proxy.BuyProducts(int.Parse(tbOrderNo.Text), temp);
            if (answer == null)
            {
                tbOrderStatus.Text = "The order number " + tbOrderNo.Text + " is being prepared";
                tbOrderNo.Clear();
                tbTotalPrice.Clear();
                lbPrice.Items.Clear();
                lbProducts.Items.Clear();
            }
            else tbOrderStatus.Text = "Product out of stock " + answer;
        }

        private void LbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int price = 0;
            foreach (int item in (sender as ListBox).SelectedIndices)
            {
                price += int.Parse(lbPrice.Items[item].ToString());
            }
            tbTotalPrice.Text = price.ToString();
        }
    }
}
