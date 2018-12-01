using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentClient
{
    public partial class ClientForm : Form
    {
       
        public ClientForm()
        {
            InitializeComponent();            
        }

        private void lbAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selected = lbAvailable.SelectedItem;
            if (selected != null)
            {
                btnMakeOffer.Text = "sign in to " + selected;
            }

        }
    }
}
