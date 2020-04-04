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
           
        }
        public string userlogin1;
        public string userpass1;
        public void fromNew()
        {
            welName.Text = "Welcome " + New_User.welcomeName;
            pictureBox1.ImageLocation = New_User.pic;
            userlogin1 = New_User.loginName;
            userpass1 = New_User.userPass;

        }
        public void fromLogin()
        {
            welName.Text = "Welcome " + Login.username;
            pictureBox1.ImageLocation = Login.userpic;
            userlogin1 = Login.userlogin;
            userpass1 = Login.userpass;
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
        public static int userID;
        public static Boolean fromHome = true;
        public static Boolean cancelFromHome = true;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var res = userBO.toEditData(userlogin1, userpass1);
            username = res.uname;
            userlogin = res.ulog;
            userpass = res.upass;
            useremail = res.uemail;
            userDOB = res.udob;
            useradd = res.uadd;
            userAge = res.uage;
            userID = res.userID;
            fromHome = false;
            cancelFromHome = false;
            this.Hide();
            New_User nU = new New_User();
            nU.fromHome();
            nU.Show();
        }
    }
}