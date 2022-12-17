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
    public partial class Increase : Form
    {
        public Increase()
        {
            InitializeComponent();
            string con_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(con_string);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            connection.Open();

            command.CommandText = $@"Select Group_Name, instock from Stock";


            SqlDataReader sqlDataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        public void increase_Stock()
        {
            string con_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(con_string);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            connection.Open();
            int units = 0;
            string get_units_query = $@"Select * from Stock where Group_name = '{bgtextbox.Text}'";
            command.CommandText = get_units_query;
            SqlDataReader units_reader = command.ExecuteReader();
            while (units_reader.Read())
            {
                units = (int)units_reader["inStock"];
            }
            units += Convert.ToInt32(unitscombobox.Text);
            units_reader.Close();
            string query = @$"Update Stock Set inStock = '{units}' where Group_name = '{bgtextbox.Text}'";
            
            command.CommandText = query;
            command.ExecuteNonQuery();

            command.CommandText = $@"Select Group_Name, instock from Stock";

            SqlDataReader sqlDataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            dataGridView1.DataSource = dataTable;
            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //close
            this.Hide();
        }

        private void Increase_Load(object sender, EventArgs e)
        {

        }

        private void increasebutton_Click(object sender, EventArgs e)
        {
            increase_Stock();
        }
    }
}
