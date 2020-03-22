using System;
using UMS_BAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMS
{
    public partial class New_User : Form
    {
        public static String welcomeName = "";
        public static String loginName = "";
        public static String userPass = "";
        public static String pic = "";
        public New_User()
        {
            InitializeComponent();
        }

        private void New_User_Load(object sender, EventArgs e)
        {
            genderBox.Items.Add('M');
            genderBox.Items.Add('F');
        }

        private void nameText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void passText_TextChanged(object sender, EventArgs e)
        {
            passText.PasswordChar = '*';
            passText.MaxLength = 14;
        }

        private void emailText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void loginText_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameVal(object sender, EventArgs e)
        {

        }
        public void fromHome()
        {
            nameText.Text = Home.username;
            loginText.Text = Home.userlogin;
            emailText.Text = Home.useremail;
            passText.Text = Home.userpass;
            addressBox.Text = Home.useradd;
            ageCount.Value = Home.userAge;
            dobPicker.Value = Home.userDOB.Date;
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            var result = uploadFile.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string file = uploadFile.FileName;
                pictureBox.Load(file);
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (mainForm.fromNew == true)
            {
                mainForm.fromNew = false;
                fromNewUser();
            }
            else
            {
                Home.fromHome = false;
                fromHomeForEdit();
            }
        }
        private void fromHomeForEdit()
        {
            userBO.updateData(nameText.Text, loginText.Text, passText.Text, emailText.Text, genderBox.Text, addressBox.Text, ageCount.Value, nicBox.Text, dobPicker.Value.Date, cricket.Checked, hockey.Checked, chess.Checked, pictureBox.ImageLocation, Home.userID);
        }
        private void fromNewUser()
        {
            nameText.MaxLength = 20;
            if (nameText.Text == "")
            {
                MessageBox.Show("must enter your name");
            }
            else if (loginText.Text == "")
            {
                MessageBox.Show("Must enter your login");
            }
            else if (passText.Text == "")
            {
                MessageBox.Show("Must enter a strong password!!!");
            }
            else if (!(emailText.Text.Contains("@gmail.com")))
            {
                MessageBox.Show("Plaese enter Email correctly...(abc@gmail.com)");
            }
            else if (genderBox.Text == "")
            {
                MessageBox.Show("Please choose your gender...M/F");
            }
            else if (addressBox.Text == "")
            {
                MessageBox.Show("Please enter your address.");
            }
            else if (ageCount.Value == 0)
            {
                MessageBox.Show("Please enter your age.");
            }
            else if (!nicBox.MaskCompleted)
            {
                MessageBox.Show("Please enter your complete CNIC no.");
            }
            else
            {
                var res = userBO.loginEmailValidation(loginText.Text, emailText.Text);
                if (res == false)
                {
                    var r = userBO.insertUser(nameText.Text, loginText.Text, passText.Text, emailText.Text, genderBox.Text, addressBox.Text, ageCount.Value, nicBox.Text, dobPicker.Value.Date, cricket.Checked, hockey.Checked, chess.Checked, pictureBox.ImageLocation);
                    welcomeName = nameText.Text;
                    userPass = passText.Text;
                    pic = pictureBox.ImageLocation;
                    loginName = loginText.Text;
                    this.Hide();
                    Home h = new Home();
                    h.fromNew();
                    h.Show();
                }
                else
                {
                    MessageBox.Show("User already exist!!!");
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm mF = new mainForm();
            mF.Show();
        }
    }
}
