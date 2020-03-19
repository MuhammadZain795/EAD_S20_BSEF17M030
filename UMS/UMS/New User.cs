using System;
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
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = @"DESKTOP-IND7HCK\SQLEXPRESS";
                builder.InitialCatalog = "Assignment4";
                builder.UserID = "sa";
                builder.Password = "1234";
                String connString = builder.ToString();
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    DateTime dt = DateTime.Now;
                    String query = @"Insert into dbo.users Values('" + nameText.Text + "', '" + loginText.Text + "', '" + passText.Text + "', '" + genderBox.Text + "', '" + addressBox.Text + "', '" + ageCount.Value + "', '" + nicBox.Text + "', '" + dobPicker.Value.Date + "', '" + cricket.Checked + "', '" + hockey.Checked + "', '" + chess.Checked + "', '" + pictureBox.ImageLocation + "', '" + dt + "'); ";
                    SqlCommand command = new SqlCommand(query, conn);
                    int res = command.ExecuteNonQuery();
                }
                this.Hide();
                Home h = new Home();
                h.Show();
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
