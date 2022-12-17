using Microsoft.Win32;
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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }
         String username, password, secretpassword = "Bloodbank";
        public static String usernamevar, passwordvar, secretpasswordvar;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //show password
            if (linkLabel1.Text == "Show")
            {
                linkLabel1.Text = "Hide";
                passwordTextBox.PasswordChar = '\0';
            }
            else
            {
                linkLabel1.Text = "Show";
                passwordTextBox.PasswordChar = '*';
            }
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void signupbutton_Leave(object sender, EventArgs e)
        {
            signupbutton.BackColor = Color.White;
            signupbutton.ForeColor = Color.Black;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //show Confirm password
            if (linkLabel2.Text == "Show")
            {
                linkLabel2.Text = "Hide";
                secretpasswordTextBox.PasswordChar = '\0';
            }
            else
            {
                linkLabel2.Text = "Show";
                secretpasswordTextBox.PasswordChar = '*';
            }

        }



        private void signupbutton_MouseHover(object sender, EventArgs e)
        {
                signupbutton.BackColor = Color.Green;
                signupbutton.ForeColor = Color.White;
            

        }

        private void signupbutton_Click(object sender, EventArgs e)
        {
            signup();


            //checking if entries are completely entered
            if (usernamevar == null || passwordvar == null || secretpasswordvar == null)
            {
                MessageBox.Show("Please fill all the entries");            
            }

            //checking if signup entries are same as initialized
            if (secretpasswordvar == secretpassword)
            {

                LoginForm loginform = new LoginForm();
                this.Hide();
                loginform.Show();
            }
            
            else
            {
                MessageBox.Show("Incorrect Username, password or secretPassword");
            }
        }


        //method for sign up initializing
        public void signup()
        {
            usernamevar = userNameTextBox.Text;
            passwordvar = passwordTextBox.Text;
            secretpasswordvar = secretpasswordTextBox.Text;


        }
        

        
    }
}
