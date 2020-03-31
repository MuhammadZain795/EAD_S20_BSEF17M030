using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_DAL
{
    public static class userDAO
    {

        private static String connString = "Data Source=DESKTOP-IND7HCK\\SQLEXPRESS; Initial Catalog=Assignment4;User ID=sa;Password=1234";
        public static Boolean loginEmailValidationForExisting(String login, String email,int ID)
        {
            SqlDataReader l, e;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query1 = @"Select Login from dbo.users where Login='" + login + "' and userID!='"+ID+"'";
                SqlCommand command1 = new SqlCommand(query1, conn);
                l = command1.ExecuteReader();
                bool l1 = l.Read();
                l.Close();
                String query2 = @"Select Email from dbo.users where Email='" + email + "' and userID!='"+ID+"'";
                SqlCommand command2 = new SqlCommand(query2, conn);
                e = command2.ExecuteReader();
                if (l1 == true || e.Read() == true)
                {
                    return true;
                }
                return false;
            }
        }
        public static Boolean loginEmailValidationForNew(String login, String email)
        {
            SqlDataReader l,e;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query1 = @"Select Login from dbo.users where Login='" + login + "'";
                SqlCommand command1 = new SqlCommand(query1, conn);
                l = command1.ExecuteReader();
                bool l1 = l.Read();
                l.Close();
                String query2 = @"Select Email from dbo.users where Email='" + email + "'";
                SqlCommand command2 = new SqlCommand(query2, conn);
                e = command2.ExecuteReader();
                if(l1==true || e.Read() == true)
                {
                    return true;
                }
                return false;
            }
        }
        public static int insertUser(String name, String login, String pass, String email, String gender, String add, decimal age, String NIC, DateTime DOB, bool cri, bool hoc, bool chess, String image)
        {
            using (SqlConnection conn1 = new SqlConnection(connString))
            {
                conn1.Open();
                DateTime dt = DateTime.Now;
                String query = @"Insert into dbo.users Values('" + name + "', '" + login + "', '" + email + "','" + pass + "', '" + gender + "', '" + add + "', '" + age + "', '" + NIC + "', '" + DOB + "', '" + cri + "', '" + hoc + "', '" + chess + "', '" + image + "', '" + dt + "'); ";
                SqlCommand command2 = new SqlCommand(query, conn1);
                int res = command2.ExecuteNonQuery();
                return res;
            }
        }
        public static int updateData(String name, String login, String pass, String email, String gender, String add, decimal age, String NIC, DateTime DOB, bool cri, bool hoc, bool chess, String image, int userID)
        {
            using (SqlConnection conn1 = new SqlConnection(connString))
            {
                conn1.Open();
                DateTime dt = DateTime.Now;
                String query = @"Update dbo.users Set Name='"+name+"',Login='"+login+"',Password='"+pass+"',Email='"+email+"',Gender='"+gender+"',Address='"+add+"',Age='"+age+"',NIC='"+NIC+"',DOB='"+DOB+"',Cricket='"+cri+"',Hockey='"+hoc+"',Chess='"+chess+"',ImageName='"+image+"',CreatedOn='"+dt+"' where userID='"+userID+"'";
                SqlCommand command2 = new SqlCommand(query, conn1);
                int res = command2.ExecuteNonQuery();
                return res;
            }
        }
        public struct userData
        {
            public String uname;
            public String ulog;
            public String uemail;
            public String upass;
            public String uadd;
            public DateTime udob;
            public decimal uage;
            public int userID;
        }
        public static userData toEditData(String login, String pass)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                userData ud = new userData();
                String query = @"Select userID,Name,Login,Email,Password,Address,DOB,Age,NIC from dbo.users where Login='"+login+"'and Password='"+pass+"';";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader temp = command.ExecuteReader();
                temp.Read();
                ud.uname = temp["Name"].ToString();
                ud.ulog = temp["Login"].ToString();
                ud.uemail = temp["Email"].ToString();
                ud.upass = temp["Password"].ToString();
                ud.uadd = temp["Address"].ToString();
                ud.udob = Convert.ToDateTime(temp["DOB"]);
                ud.uage = Convert.ToDecimal(temp["Age"]);
                ud.userID = Convert.ToInt32(temp["userID"]);
                return ud;
            }
        }
        public static String username;
        public static String userpic;
        public static Boolean loginUser(String login,String pass)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query = @"Select Name,ImageName from dbo.users where Login='" + login + "'and Password='" + pass + "';";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader temp = command.ExecuteReader();
                if (temp.Read() == true)
                {
                    username = temp["Name"].ToString();
                    userpic = temp["ImageName"].ToString();
                    return true;
                }
                return false;
            }
        }
        public static Boolean verifyAdmin(String login,String pass)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query = @"Select * from dbo.Admin where Login='" + login + "'and Password='" + pass + "';";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader temp = command.ExecuteReader();
                return temp.Read();
            }
        }
        public static List<Int32> idList = new List<Int32>();
        public static List<String> nameList = new List<string>();
        public static List<String> loginList = new List<string>();
        public static List<String> passlist = new List<string>();
        public static List<String> addressList = new List<string>();
        public static List<Decimal> ageList = new List<Decimal>();
        public static List<DateTime> doblist = new List<DateTime>();
        public static userDataList.userDataClass loadUsersData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query1 = @"Select userID,Name,Login,Password,Address,Age,DOB from dbo.users;";
                SqlCommand command1 = new SqlCommand(query1, conn);
                SqlDataReader temp1 = command1.ExecuteReader();
                while (temp1.Read())
                {
                    idList.Add((Int32)temp1["userID"]);
                    nameList.Add((String)temp1["Name"]);
                    loginList.Add((String)temp1["Login"]);
                    addressList.Add((String)temp1["Address"]);
                    ageList.Add(Convert.ToDecimal(temp1["Age"]));
                    passlist.Add((String)temp1["Password"]);
                    doblist.Add(Convert.ToDateTime(temp1["DOB"]));
                }
                var listOfListsOfData = new userDataList.userDataClass();
                listOfListsOfData.idlist = idList;
                listOfListsOfData.namelist = nameList;
                listOfListsOfData.loginlist = loginList;
                listOfListsOfData.passlist = passlist;
                listOfListsOfData.addresslist = addressList;
                listOfListsOfData.agelist = ageList;
                listOfListsOfData.doblist = doblist;
                return listOfListsOfData;
            }
        }
        public static String getMail(String login)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query1 = @"Select Email from dbo.users where Login='"+login+"' ;";
                SqlCommand command1 = new SqlCommand(query1, conn);
                SqlDataReader temp1 = command1.ExecuteReader();
                if (temp1.Read() == true) 
                {
                    String mail = temp1["Email"].ToString();
                    return mail;
                }
                return "Null";
            }
        }
        public static void updatePass(String login, String pass)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query1 = @"Update dbo.users Set Password='"+pass+"' where Login='" + login + "'";
                SqlCommand command1 = new SqlCommand(query1, conn);
                int l = command1.ExecuteNonQuery();
            }
        }
        public static DataForAdminToEdit.Class1  getDataForAdminEdit(Int32 id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                DataForAdminToEdit.Class1 ud = new DataForAdminToEdit.Class1();
                String query = @"Select Name,Login,Password,Address,Age from dbo.users where userID='" + id + "';";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader temp = command.ExecuteReader();
                temp.Read();
                ud.Name = temp["Name"].ToString();
                ud.Login = temp["Login"].ToString();
                ud.Password = temp["Password"].ToString();
                ud.Address = temp["Address"].ToString();
                ud.Age = Convert.ToDecimal(temp["Age"]);
                return ud;
            }
        }
        public static DataTable userDetail()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select userID,Name,login,address,Age from dbo.users", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}