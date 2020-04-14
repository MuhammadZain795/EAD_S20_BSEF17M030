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
        private static String connString = "Data Source=DESKTOP-IND7HCK\\SQLEXPRESS; Initial Catalog=Assignment3;User ID=sa;Password=1234";
        public static Boolean loginValidationForNew(String login)
        {
            SqlDataReader l;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query1 = @"Select Login from dbo.users where Login='" + login + "'";
                SqlCommand command1 = new SqlCommand(query1, conn);
                l = command1.ExecuteReader();
                if (l.Read())
                {
                    return true;
                }
                return false;
            }
        }
        public static void insertUser(String name, String login, String pass)
        {
            using (SqlConnection conn1 = new SqlConnection(connString))
            {
                conn1.Open();
                String query = @"Insert into dbo.users(Name,Login,Password) Values('" + name + "', '" + login + "','" + pass + "'); ";
                SqlCommand command2 = new SqlCommand(query, conn1);
                SqlDataReader res = command2.ExecuteReader();
                
            }
        }
        public static Boolean loginUser(String login, String pass)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query = @"Select * from dbo.users where Login='" + login + "'and Password='" + pass + "';";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader temp = command.ExecuteReader();
                if (temp.Read() == true)
                    return true;
                return false;
            }
        }
    }
}
