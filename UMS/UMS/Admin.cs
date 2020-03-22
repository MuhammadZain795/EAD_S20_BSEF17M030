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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            passText.PasswordChar = '*';
            passText.MaxLength = 14;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Boolean res = userBO.verifyAdmin(loginText.Text, passText.Text);
            if (res == true)
            {
                this.Hide();
                Admin_Home ad = new Admin_Home();
                ad.Show();
            }
            else
            {
                MessageBox.Show("Login or Password is incorrect!!!");
            }
        }
    }
}
