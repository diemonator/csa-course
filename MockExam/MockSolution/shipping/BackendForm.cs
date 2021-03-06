﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using server.MyBackendService;

namespace backend
{
    public partial class BackendForm : Form
    {
        private BackofficeClient proxy;

        public BackendForm()
        {
            InitializeComponent();
            proxy = new BackofficeClient();
        }

        private void UpdateOrdersBtn_Click(object sender, EventArgs e)
        {
            Order[] orders = proxy.GetOrderList();
            ShowOrders(orders);
        }

        private void ShowOrders(Order[] orders)
        {
            idListBox.Items.Clear();
            dateTimeBox.Items.Clear();
            for (int i = 0; i < orders.Count(); i++)
            {
                /*idListBox.Items.Add(orders[i].ProductId);
                dateTimeBox.Items.Add(formatTime(orders[i].Moment));*/

                idListBox.Items.Add(orders[i].OrderId);
                dateTimeBox.Items.Add(orders[i].ProductId + " - " + FormatTime(orders[i].Moment));
            }
        }

        private string FormatTime(DateTime t)
        {
            string s  = t.ToString("HH") + "h";
            s += t.ToString("mm") + "m";
            s += t.ToString("ss") + "s";
            return s;
        }

        public void OrderArrived(Order order)
        {
            idListBox.Items.Add(order.OrderId);
            dateTimeBox.Items.Add(order.ProductId + " - " + FormatTime(order.Moment));
        }


        public void OrderShipped(Order order)
        {
            int index = idListBox.Items.IndexOf(order.OrderId);
            if (index >= 0)
            {
                idListBox.Items.RemoveAt(index);
                dateTimeBox.Items.RemoveAt(index);
            }
        }
    }
}
