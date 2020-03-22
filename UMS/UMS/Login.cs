using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_BAL;

namespace UMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm mF = new mainForm();
            mF.Show();
        }
        public static String username;
        public static String userpic;
        public static String userlogin;
        public static String userpass;
        public static Boolean cancelFromLogin;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Boolean res = userBO.loginUser(loginText.Text,passText.Text);
            if (res == true)
            {
                userlogin = loginText.Text;
                userpass = passText.Text;
                username = userBO.username;
                userpic = userBO.userpic;
                this.Hide();
                Home h = new Home();
                cancelFromLogin = true;
                h.fromLogin();
                h.Show();
            }
            else
            {
                MessageBox.Show("Login or Password is incorrect!!!");
            }
        }

        private void passText_TextChanged(object sender, EventArgs e)
        {
            passText.PasswordChar = '*';
            passText.MaxLength = 14;
        }
    }
}
