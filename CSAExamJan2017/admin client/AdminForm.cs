using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using admin_client.ServiceReference;

namespace admin_client
{
    public partial class AdminForm : Form
    {
        private AdministratorClient proxy;
        public AdminForm()
        {
            InitializeComponent();
            proxy = new AdministratorClient();
        }

        private void BtnGetOffers_Click(object sender, EventArgs e)
        {
            lbOffers.Items.Clear();
            string name = tbName.Text;
            if (name != null)
            {
                int[] offers = proxy.GetAllOffers(name);
                foreach (int money in offers)
                {
                    lbOffers.Items.Add(money);
                }
            }
        }
    }
}
