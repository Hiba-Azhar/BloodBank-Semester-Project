using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankProject
{
    public partial class StockDetails : Form
    {
        public StockDetails()
        {
            InitializeComponent();
            show_Details();
        }

        public void show_Details()
        {
            string con_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(con_string);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            connection.Open();
            command.CommandText = @"Select * from Stock";

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            connection.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //close
            this.Hide();
        }
    }
}
