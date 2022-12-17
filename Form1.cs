namespace BloodBankProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public static String username, password = null;
        

        //click event of login button
        private void loginbutton_Click(object sender, EventArgs e)
        {

            username = userNameTextBox.Text;
            password = passwordTextBox.Text;


            //checking if account is correct
            if ((username == SignUpForm.usernamevar && password == SignUpForm.passwordvar) || (username=="Hiba@bloodbank.health" && password == "123"))
            {
                Dashboard dashboard = new Dashboard();
                this.Hide();
                dashboard.Show();
                
            }

            else
            {
                MessageBox.Show("Incorrect Username or password");
            }

            

            

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignUpForm signupobj = new SignUpForm();
            signupobj.Show();
        }

        private void showlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (showlink.Text == "Show")
            {
                showlink.Text = "Hide";
                passwordTextBox.PasswordChar = '\0';
            }
            else
            {
                showlink.Text = "Show";
                passwordTextBox.PasswordChar = '*';
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void loginbutton_Leave(object sender, EventArgs e)
        {
            loginbutton.BackColor = Color.White;
            loginbutton.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginbutton_MouseHover(object sender, EventArgs e)
        {   
            loginbutton.BackColor = Color.Green;
            loginbutton.ForeColor = Color.White;
        }

        
    }
}