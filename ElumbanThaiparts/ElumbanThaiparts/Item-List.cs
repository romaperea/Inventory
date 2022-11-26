using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ElumbanThaiparts
{
    public partial class Item_in : Form
    {
        public Item_in()
        {
            InitializeComponent();
        }

        private void Item_in_Load(object sender, EventArgs e)
        {
            StatusCb.SelectedIndex = 0;
            LoadData();
           
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            con.Open();
            bool status = false;
            if (StatusCb.SelectedIndex == 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            var sqlQuery = "";
            if (IfItemExists(con, ItemTb.Text))
            {
                sqlQuery = @"UPDATE [Items] SET [ItemName] = '" + ItemName.Text + "' ,[ItemStatus] = '" + status + "' WHERE [ItemCode] = '" + ItemTb.Text + "'";
            }
            else
            {
                sqlQuery = @"INSERT INTO [dbo].[Items] ([ItemCode],[ItemName],[ItemStatus]) VALUES
           ('" + ItemTb.Text + "','" + ItemName.Text + "','" + status + "')";
            }
            
           
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
            LoadData();
           

        }
        private bool IfItemExists(SqlConnection con, string ItemCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [Stock].[dbo].[Items] WHERE ='" + ItemCode + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Stock].[dbo].[Items]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ItemDGV.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = ItemDGV.Rows.Add();
                ItemDGV.Rows[n].Cells[0].Value = item["ItemCode"].ToString();
                ItemDGV.Rows[n].Cells[1].Value = item["ItemName"].ToString();
                if ((bool)item["ItemStatus"])
                {
                    ItemDGV.Rows[n].Cells[2].Value = "Active";

                }
                else
                {
                    ItemDGV.Rows[n].Cells[2].Value = "Deactivate";
                }
            }
        }

        private void ItemDGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ItemTb.Text = ItemDGV.SelectedRows[0].Cells[0].Value.ToString();
            ItemName.Text = ItemDGV.SelectedRows[0].Cells[0].Value.ToString();
            StatusCb.SelectedText = ItemDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (ItemDGV.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                StatusCb.SelectedIndex = 0;
            }
            else
            {
                StatusCb.SelectedIndex = 1;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
           
            
            
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var sqlQuery = "";
            if (IfItemExists(con, ItemTb.Text))
            {

                con.Open();
                sqlQuery = @"DELETE FROM [Items] WHERE [ItemCode] = '" + ItemTb.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Record not Exists");
            }


            
            LoadData();
        }
    }
}



 
