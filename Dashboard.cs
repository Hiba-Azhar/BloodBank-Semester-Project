using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankProject
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewDonor addnewdonor = new AddNewDonor();
            addnewdonor.Show();
            
        }

        private void allDonorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllDonors allDonors = new AllDonors();
            allDonors.Show();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DononrByAddress dononrByAddress = new DononrByAddress();
            dononrByAddress.Show();
        }

        private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Increase increase = new Increase();
            increase.Show();
        }

        private void updateDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDonor updateDonor = new UpdateDonor();    
            updateDonor.Show();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockDetails stockdetails = new StockDetails();
            stockdetails.Show();
        }

        private void bLoodGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDonorsByBloodgroup searchBYBlood = new SearchDonorsByBloodgroup();
            searchBYBlood.Show();
        }

        private void deleteDonorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDonor delete_D = new DeleteDonor();
            delete_D.Show();
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Decrease decrease = new Decrease();
            decrease.Show();
        }
    }
}
