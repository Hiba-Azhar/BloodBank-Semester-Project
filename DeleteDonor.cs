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
    public partial class DeleteDonor : Form
    {
        public DeleteDonor()
        {
            InitializeComponent();

            string con_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(con_string);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            connection.Open();

            command.CommandText = $@"Select * from Donors";

            SqlDataReader sqlDataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            string con_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(con_string);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            connection.Open();

            command.CommandText = $@"Delete From Donors Where id = {idSearch.Text}";
            command.ExecuteNonQuery();

            command.CommandText = $@"Select * from Donors";

            SqlDataReader sqlDataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idSearch.Text = e.RowIndex.ToString();
        }
    }
}
