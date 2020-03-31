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
    public partial class Admin_Home : Form
    {
        public Admin_Home()
        {
            InitializeComponent();
        }
        public static Boolean notFirstTime = false;
        private void Admin_Home_Load(object sender, EventArgs e)
        {
            if (notFirstTime == false)
            {
                firstTime();
            }
            else
            {
                this.dataGridView1.Rows.Clear();
                firstTime();
            }
        }
        private void firstTime()
        {
            notFirstTime = true;
            userDataList.userDataClass userDataClass = userBO.loadUsersData();
            int count = userDataClass.idlist.Count();
            for (int i = 0; i < count; i++)
            {
                userDTOBindingSource.Add(new userDTO() { UserID = userDataClass.idlist[i], Name = userDataClass.namelist[i], Login = userDataClass.loginlist[i], Address = userDataClass.addresslist[i], Age = userDataClass.agelist[i] });
            }
        } 
        public static Boolean fromAdmin;
        public static Boolean cancelFromAdmin;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                fromAdmin = true;
                cancelFromAdmin = true;
                New_User nu = new New_User();
                nu.fromAdmin(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue));
                nu.Show();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            this.Hide();
            mainForm.Show();
        }
    }
}
