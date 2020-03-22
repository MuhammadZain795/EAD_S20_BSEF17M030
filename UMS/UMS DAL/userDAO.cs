using System;
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
        public static LinkedList<Int32> idList = new LinkedList<Int32>();
        public static LinkedList<String> nameList = new LinkedList<string>();
        public static LinkedList<String> loginList = new LinkedList<string>();
        public static LinkedList<String> addressList = new LinkedList<string>();
        public static LinkedList<Decimal> ageList = new LinkedList<Decimal>();
        public static void loadUsersData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query1 = @"Select userID,Name,Login,Address,Age from dbo.users;";
                SqlCommand command1 = new SqlCommand(query1, conn);
                SqlDataReader temp1 = command1.ExecuteReader();
                while (temp1.Read())
                {
                    idList.AddLast((Int32)temp1["userID"]);
                    nameList.AddLast((String)temp1["Name"]);
                    loginList.AddLast((String)temp1["Login"]);
                    addressList.AddLast((String)temp1["Address"]);
                    ageList.AddLast(Convert.ToDecimal(temp1["Age"]));
                }
                
            }
        }
    }
}