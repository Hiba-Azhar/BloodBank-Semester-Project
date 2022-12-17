using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankProject
{
    public partial class UpdateDonor : Form
    {
        public UpdateDonor()
        {
            InitializeComponent();
        }

        private void UpdateDonor_Load(object sender, EventArgs e)
        {

        }
        private void update_donor()
        {
            string con_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(con_string);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            string gen = "";
            if (maleradiobutton.Checked)
                gen = "male";
            else if (femaleradiobutton.Checked)
                gen = "female";

            connection.Open();
            string query = $@"Update Donors SET name = '{nametextbox.Text}', lastname = '{lastnametextbox.Text}', DOB = '{dobtextbox.Text}' , Email = '{emailtextbox.Text}', Bgroup = '{bgtextbox.Text}'
            ,City = '{citytextbox.Text}', address = '{addresstextbox.Text}', gender = '{gen}', date = '{dobtextbox.Text}', phone_no = '{mobiletextbox.Text}'
            where id = '{donoridtextbox.Text}'";

            // 
            // ,, 

            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //close
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //app close

            Application.Exit();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            update_donor();
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            string con_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(con_string);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            connection.Open();
            string query = $@"Select * from Donors where id = '{Convert.ToInt32(donoridtextbox.Text)}'";

            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nametextbox.Text = (string)reader["Name"];
                lastnametextbox.Text = (string)reader["lastname"];
                dobtextbox.Text = (string)reader["DOB"];
                mobiletextbox.Text = "" + (int)reader["phone_no"];
                emailtextbox.Text = (string)reader["email"];
                bgtextbox.Text = (string)reader["BGroup"];
                citytextbox.Text = (string)reader["city"];
                addresstextbox.Text = (string)reader["address"];

                if ((string)reader["gender"] == "male")
                    maleradiobutton.Checked = true;
                if ((string)reader["gender"] == "female")
                    femaleradiobutton.Checked = true;

            }

            connection.Close();
        }
    }
}
