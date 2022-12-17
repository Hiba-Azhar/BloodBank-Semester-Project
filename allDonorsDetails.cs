using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BloodBankProject
{
    public partial class AllDonors : Form
    {
        public AllDonors()
        {
            InitializeComponent();
            showDonors();
        }

        public void showDonors()
        {
            string con_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
            SqlConnection connection = new SqlConnection(con_string);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            connection.Open();
            command.CommandText = @"Select * from dbo.Donors";

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            dataGridView1.DataSource = dt;      
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //close

            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
