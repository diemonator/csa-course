using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using client.MyWebshopService;

namespace client
{
    public partial class ClientForm : Form, IWebshopCallback
    {
        private WebshopClient proxy;

        public ClientForm()
        {
            InitializeComponent();
            InstanceContext context = new InstanceContext(this);
            proxy = new WebshopClient(context);
            if (proxy != null)
            {
                ShowStatus(proxy.GetWebshopName());
                ShowProductList(proxy.GetProductList());
                proxy.RegisterStockUpdate();
            }
        }

        private string FormatTime(DateTime t)
        {
            string s = t.ToString("HH") + "h";
            s += t.ToString("mm") + "m";
            s += t.ToString("ss") + "s";
            return s;
        }

        private void ShowStatus(string message)
        {
            lblNotifications.Text = message;
        }

        private void GetWebShopName_Click(object sender, EventArgs e)
        {
            ShowStatus(proxy.GetWebshopName());
        }

        private void ShowProductList(Item[] items)
        {
            idListBox.Items.Clear();
            priceListBox.Items.Clear();
            stockListBox.Items.Clear();
            for (int i = 0; i < items.Count(); i++)
            {
                idListBox.Items.Add(items[i].ProductId);
                priceListBox.Items.Add(items[i].Price);
                stockListBox.Items.Add(items[i].Stock);
            }
        }

        private void GetProductList_Click(object sender, EventArgs e)
        {
            Item[] items = proxy.GetProductList();
            ShowProductList(items);
        }

        private void GetProductInfo_Click(object sender, EventArgs e)
        {
            string name = tbProductName.Text;
            string info = proxy.GetProductInfo(name);
            string result;
            if (info != "") result = info;
            else result = "no info on product \"" + name + "\"";
            ShowStatus(result);
        }

        private void BuyProduct_Click(object sender, EventArgs e)
        {
            string result;
            if (idListBox.SelectedItems.Count > 0)
            {
                string id = idListBox.SelectedItems[0].ToString();
                bool productBought = proxy.BuyProduct(id);
                if (productBought) result = "you bought one copy of \"" + id + "\"";
                else result = "you did not buy a copy of \"" + id + "\"";
                Item[] items = proxy.GetProductList();
                ShowProductList(items);
            }
            else result = "please select a product id first";
            ShowStatus(result);
        }

        public void ProductShipped(string productId, DateTime shippingMoment)
        {
            ShowStatus(productId + " was shipped at " + FormatTime(shippingMoment));
        }

        public void UpdateStock(Item[] products)
        {
            ShowProductList(products);
        }
    }
}

