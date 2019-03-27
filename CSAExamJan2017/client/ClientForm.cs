using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentClient.ServiceReference;
using System.ServiceModel;

namespace RentClient
{
    public partial class ClientForm : Form, IAgencyCallback
    {
        private AgencyClient proxy;  
        public ClientForm()
        {
            InitializeComponent();
            proxy = new AgencyClient(new InstanceContext(this));
            if (proxy != null) proxy.Subscribe();
        }

        private void LbAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selected = lbAvailable.SelectedItem;
            if (selected != null) btnMakeOffer.Text = "sign in to " + selected;
        }

        private void BtnNrOffers_Click(object sender, EventArgs e)
        {
            string text = proxy.GetNumberOfOffers(tbName.Text).ToString();
            string result;
            if (text != null) result = "The number of offers for the house on address " + tbName.Text + " is: " + text;
            else result = "The house does not exsist!";
            rtbMessages.AppendText(result);
        }

        private void BtnMakeOffer_Click(object sender, EventArgs e)
        {
            string result;
            if (proxy.AddOffer(lbAvailable.SelectedItem.ToString(), int.Parse(tbOffer.Text)))
            {
                result = "Successfuly made offer!";
                lbAvailable.Items.Clear();
                BtnGetAvailable_Click(btnGetAvailable, EventArgs.Empty);
            }
            else result = "Not successfuly  offer!";
            rtbMessages.AppendText(result);
        }

        private void BtnGetAvailable_Click(object sender, EventArgs e)
        {
            List<House> house = proxy.GetAvailableHouses();
            house.ForEach(x => lbAvailable.Items.Add(x.Address));
        }

        private void BtnAskPrice_Click(object sender, EventArgs e)
        {
            string result;
            string text = proxy.GetHousePrice(tbName.Text).ToString();
            if (text != null) result = "The price of the house on address " + tbName.Text + " is: " + text;
            else result = "The house does not exsist!";
            rtbMessages.AppendText(result);
        }

        public void Notify(string address)
        {
            if (lbAvailable.Items.Count != 0) lbAvailable.Items.Remove(address);
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            proxy.Unsubscribe();
        }
    }
}
