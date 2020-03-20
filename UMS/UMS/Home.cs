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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            welName.Text = "Welcome " + New_User.welcomeName;
            pictureBox1.ImageLocation = New_User.pic;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm mf = new mainForm();
            mf.Show();
        }
    }
}
