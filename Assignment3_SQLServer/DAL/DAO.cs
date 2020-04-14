using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAO
    {
        private static String connString = "Data Source=DESKTOP-IND7HCK\\SQLEXPRESS; Initial Catalog=Assignment4;User ID=sa;Password=1234";
        public static Boolean loginEmailValidationForExisting(String login, String email, int ID)
        {
            SqlDataReader l, e;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query1 = @"Select Login from dbo.users where Login='" + login + "' and userID!='" + ID + "'";
                SqlCommand command1 = new SqlCommand(query1, conn);
                l = command1.ExecuteReader();
                bool l1 = l.Read();
                l.Close();
                String query2 = @"Select Email from dbo.users where Email='" + email + "' and userID!='" + ID + "'";
                SqlCommand command2 = new SqlCommand(query2, conn);
                e = command2.ExecuteReader();
                if (l1 == true || e.Read() == true)
                {
                    return true;
                }
                return false;
            }
        }
        public static int insertUser(String name, String login, String pass)
        {
            using (SqlConnection conn1 = new SqlConnection(connString))
            {
                conn1.Open();
                DateTime dt = DateTime.Now;
                String query = @"Insert into dbo.users Values('" + name + "', '" + login + "','" + pass + "'); ";
                SqlCommand command2 = new SqlCommand(query, conn1);
                int res = command2.ExecuteNonQuery();
                return res;
            }
        }
        public static Boolean loginUser(String login, String pass)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query = @"Select Name,ImageName from dbo.users where Login='" + login + "'and Password='" + pass + "';";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader temp = command.ExecuteReader();
                if (temp.Read() == true)
                    return true;
                return false;
            }
        }
    }
}
