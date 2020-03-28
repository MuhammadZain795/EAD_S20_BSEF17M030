using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMS
{
    public partial class mainForm : Form
    {
        public static Boolean fromNew;
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fromNew = true;
            this.Hide();
            New_User newF = new New_User();
            newF.Show();
        }

        private void btnExtisting_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
