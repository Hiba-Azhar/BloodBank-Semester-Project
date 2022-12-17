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
    public partial class AddNewDonor : Form
    {
        string connection_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection;
        SqlCommand command;
        int id = 1;


        public AddNewDonor()
        {
            InitializeComponent();
            connection = new SqlConnection(connection_string);
            command = new SqlCommand();
            command.Connection = connection;

        }
        function fn = new function();
        public static String name, lastname, gender,  dob,  email, bgroup, city, address = null;

        private void savebutton_Click(object sender, EventArgs e)
        {
            //save

            addDonorInfo();
            findID();
        }

        int mobile = 0;

        public void findID()
        {
            String query = "select id from Donors";
            connection.Open();
            command.CommandText = query;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                id = (int)sqlDataReader["id"] + 1;
                newdonorid.Text = "" + id;
            }
            sqlDataReader.Close();
            connection.Close();
        }
        

        private void AddNewDonor_Load(object sender, EventArgs e)
        {
            
            findID();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Close
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //reset button
            nametextbox.Clear();
            lastnametextbox.Clear();
            dobtextbox.Text = "1/1/2020";
            mobiletextbox.Clear();
            emailtextbox.Clear();
            citytextbox.Clear();
            addresstextbox.Clear();

        }


        public void addDonorInfo()
        {
            
            name = nametextbox.Text;
            lastname = lastnametextbox.Text;
            dob = dobtextbox.Text;
            email = emailtextbox.Text;
            bgroup = bgtextbox.Text;
            city = citytextbox.Text;
            address = addresstextbox.Text;
            string gen = "";

            if (male.Checked)
                gen = "Male";
            else if (female.Checked)
                gen = "Female";

            string query = $@"insert into Donors (id ,Name, lastname, address, city, dob, bgroup, gender, email, phone_no) values 
                            ('{id}','{name}','{lastname}', '{addresstextbox.Text}', '{city}', '{dob}', '{bgroup}', '{gen}', '{email}',{mobiletextbox.Text})";

            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();




        }       //addDonorInfo ends
    }
}
