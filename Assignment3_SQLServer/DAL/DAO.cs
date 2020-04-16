using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

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
        public static List<folderData> getChildFolders(int pId)
        {
            List<folderData> data = new List<folderData>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query = @"Select * from dbo.folder where ParentId='" + pId + "';";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader temp = command.ExecuteReader();
                while (temp.Read() == true)
                {
                    folderData folderData = new folderData();
                    folderData.folderId = Convert.ToInt32(temp["FolderId"]);
                    folderData.folderName = (temp["FolderName"]).ToString();
                    data.Add(folderData);
                }
                return data;
            }
        }
        public static void createFolder(String folderName,Int32 parentId)
        {
            using (SqlConnection conn1 = new SqlConnection(connString))
            {
                conn1.Open();
                String query = String.Format("Insert into dbo.folder(FolderName,ParentId) Values('{0}',{1})",folderName,parentId);
                SqlCommand command2 = new SqlCommand(query, conn1);
                SqlDataReader res = command2.ExecuteReader();

            }
        }
        public static Boolean checkName(String fname, Int32 pId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query = @"Select * from dbo.folder where FolderName='" + fname + "' and ParentId='" + pId + "'";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader temp = command.ExecuteReader();
                if (temp.Read() == true)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
