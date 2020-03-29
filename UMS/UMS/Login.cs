using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Net.Mail;
using System.Net;
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
        public static Boolean sendEmail(String toEmail, String subject, String body)
        {
            try
            {
                String fromEmail = "EAD.SEMorning@gmail.com";
                String fromPassword = "SEMorning2017";
                String fromName = "EAD";
                MailAddress fromAddress = new MailAddress(fromEmail, fromName);
                MailAddress toAddress = new MailAddress(toEmail);
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body

                })
                {
                    smtp.Send(message);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (loginText.Text == "")
            {
                MessageBox.Show("Must give login.");
            }
            else
            {
                Random random = new Random();
                int r = random.Next(1, 10);
                String email = userBO.getMail(loginText.Text);
                if (email == "Null")
                {
                    MessageBox.Show("Login Invalid.");
                }
                else 
                {
                    Boolean res = sendEmail(email, "Reset Password Code", r.ToString());
                    if (res == true)
                    {
                        String code = Interaction.InputBox("Confirm");
                        if (code == r.ToString())
                        {
                            String pass = Interaction.InputBox("Reset");
                            userBO.updatePass(loginText.Text, pass);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email not sent.");
                    }
                }
                
            }
        }
    }
}
