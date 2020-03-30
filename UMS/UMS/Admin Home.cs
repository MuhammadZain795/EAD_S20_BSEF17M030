using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_BAL;
using UMS_DAL;

namespace UMS
{
    public partial class Admin_Home : Form
    {
        public Admin_Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm mf = new mainForm();
            mf.Show();
        }
        private static void edit()
        {

        }
        private void Admin_Home_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = userBO.loadUsersData();
            //dataGridView1.DataSource = userBO.userDetail();
            
            //int pointY = 95;
            //userBO.loadUsersData();
            //int count = userBO.idList.Count;
            //for (int j = 0; j < count; j++)
            //{
            //    int pointX = 64;
            //    int changeX = 75;
            //    Button i = new Button();
            //    i.Text = (userBO.idList.First.Value).ToString();
            //    i.Location = new Point(pointX, pointY);
            //    this.Controls.Add(i);
            //    Button n = new Button();
            //    n.Text = (userBO.nameList.First.Value).ToString();
            //    userBO.nameList.RemoveFirst();
            //    n.Location = new Point(pointX+=changeX, pointY);
            //    this.Controls.Add(n);
            //    Button l = new Button();
            //    l.Text = (userBO.loginList.First.Value).ToString();
            //    userBO.loginList.RemoveFirst();
            //    l.Location = new Point(pointX+=changeX, pointY);
            //    this.Controls.Add(l);
            //    Button add = new Button();
            //    add.Text = (userBO.addressList.First.Value).ToString();
            //    userBO.addressList.RemoveFirst();
            //    add.Location = new Point(pointX+=changeX, pointY);
            //    this.Controls.Add(add);
            //    Button age = new Button();
            //    age.Text = (userBO.ageList.First.Value).ToString();
            //    userBO.ageList.RemoveFirst();
            //    age.Location = new Point(pointX+=changeX, pointY);
            //    this.Controls.Add(age);
            //    Button a = new Button();
            //    a.Text = "Edit";
            //    a.Name= (userBO.idList.First.Value).ToString();
                
            //    userBO.idList.RemoveFirst();
            //    a.Location = new Point(pointX+=changeX, pointY);
            //    this.Controls.Add(a);
            //    pointY = pointY + 25;
            //}
        }
    }
}
