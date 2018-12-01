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
                showStatus(proxy.GetWebshopName());
                showProductList(proxy.GetProductList());
                proxy.RegisterStockUpdate();
            }
        }

        private string formatTime(DateTime t)
        {
            string s = t.ToString("HH") + "h";
            s += t.ToString("mm") + "m";
            s += t.ToString("ss") + "s";
            return s;
        }

        private void showStatus(string message)
        {
            lblNotifications.Text = message;
        }

        private void GetWebShopName_Click(object sender, EventArgs e)
        {
            showStatus(proxy.GetWebshopName());
        }

        private void showProductList(Item[] items)
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
            showProductList(items);
        }

        private void GetProductInfo_Click(object sender, EventArgs e)
        {
            string name = tbProductName.Text;
            string info = proxy.GetProductInfo(name);
            if (info != "")
                showStatus(info);
            else
                showStatus("no info on product \"" + name + "\"");            
        }

        private void BuyProduct_Click(object sender, EventArgs e)
        {
            if (idListBox.SelectedItems.Count > 0)
            {
                string id = idListBox.SelectedItems[0].ToString();
                bool productBought = proxy.BuyProduct(id);
                if (productBought)
                    showStatus("you bought one copy of \"" + id + "\"");
                else
                    showStatus("you did not buy a copy of \"" + id + "\"");
                Item[] items = proxy.GetProductList();
                showProductList(items);
            }
            else
            {
                showStatus("please select a product id first");
            }
        }

        public void productShipped(string productId, DateTime shippingMoment)
        {
            showStatus(productId + " was shipped at " + formatTime(shippingMoment));
        }


        public void updateStock(Item[] products)
        {
            showProductList(products);
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}

