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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text=="admin" && TxtPass.Text=="admin123")
            {
                MessageBox.Show("Login Successful");
                new Dashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The Username or Password you entered is incorrect, try again");
                TxtUsername.Clear();
                TxtPass.Clear();
                TxtUsername.Focus();
            }
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            TxtUsername.Clear();
            TxtPass.Clear();
            TxtUsername.Focus();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
