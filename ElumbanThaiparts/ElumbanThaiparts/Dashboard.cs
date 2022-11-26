using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElumbanThaiparts
{
    public partial class Dashboard : Form
    {

        public Dashboard()
        {
            InitializeComponent();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout?",
            "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                new Login().Show();
            }
            else if (result == DialogResult.No)
            {
                //...
            }
        }

        private void ItemListPb_Click(object sender, EventArgs e)
        {
            this.Close(); //Close Form1,the current open form.

             Item_in = new Form2();

            frm2.Show(); // Launch Form2,the new form.;
        }
        }
    }

