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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (New_User.welcomeName != "")
            {
                welName.Text = "Welcome " + New_User.welcomeName;
                pictureBox1.ImageLocation = New_User.pic;
            }
            else
            {
                welName.Text = "Welcome " + Login.username;
                pictureBox1.ImageLocation = Login.userpic;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm mf = new mainForm();
            mf.Show();
        }
        public static String username;
        public static String userlogin;
        public static String userpass;
        public static String useremail;
        public static String useradd;
        public static DateTime userDOB;
        public static Decimal userAge;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (New_User.loginName!="")
            {
                var res = userBO.UpdateData(New_User.loginName, New_User.userPass);
                username = res.uname;
                userlogin = res.ulog;
                userpass = res.upass;
                useremail = res.uemail;
                userDOB = res.udob;
                useradd = res.uadd;
                userAge = res.uage;
                this.Hide();


                New_User nU = new New_User();
                nU.Show();
            }
            else
            {
                var res = userBO.UpdateData(Login.userlogin,Login.userpass);
                username = res.uname;
                userlogin = res.ulog;
                userpass = res.upass;
                useremail = res.uemail;
                userDOB = res.udob;
                useradd = res.uadd;
                userAge = res.uage;
                this.Hide();


                New_User nU = new New_User();
                nU.Show();
            }
        }
    }
}