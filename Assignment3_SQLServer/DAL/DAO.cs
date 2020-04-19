using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Entities;


namespace DAL
{
    public class DAO
    {
        private static String connString = @"server=localhost; port=3306;Uid=root;Pwd=;database=Assignment3;Convert Zero Datetime=True";
        public static Boolean loginValidationForNew(String login)
        {
            MySqlDataReader l;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String query1 = @"Select Login from dbo.users where Login='" + login + "'";
                MySqlCommand command1 = new MySqlCommand(query1, conn);
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
            using (MySqlConnection conn1 = new MySqlConnection(connString))
            {
                conn1.Open();
                String query = @"Insert into dbo.users(Name,Login,Password) Values('" + name + "', '" + login + "','" + pass + "'); ";
                MySqlCommand command2 = new MySqlCommand(query, conn1);
                MySqlDataReader res = command2.ExecuteReader();
                
            }
        }
        public static Boolean loginUser(String login, String pass)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                String query = @"Select * from dbo.users where Login='" + login + "'and Password='" + pass + "';";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader temp = command.ExecuteReader();
                if (temp.Read() == true)
                    return true;
                return false;
            }
        }
        public static List<folderData> getChildFolders(int pId)
        {
            List<folderData> data = new List<folderData>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                String query = @"Select * from dbo.folder where ParentId='" + pId + "';";
                MySqlCommand command = new MySqlCommand(query, conn);
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
            using (MySqlConnection conn1 = new MySqlConnection(connString))
            {
                conn1.Open();
                String query = String.Format("Insert into dbo.folder(FolderName,ParentId) Values('{0}',{1})",folderName,parentId);
                MySqlCommand command2 = new MySqlCommand(query, conn1);
                MySqlDataReader res = command2.ExecuteReader();

            }
        }
        public static Boolean checkName(String fname, Int32 pId)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                Boolean res1 = false;
                Boolean res2 = false;
                conn.Open();
                String query = @"Select * from dbo.folder where FolderName='" + fname + "' and ParentId='" + pId + "'";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader temp = command.ExecuteReader();
                if (temp.Read() == true)
                {
                    res1 = true;
                }
                temp.Close();
                String query1 = @"Select * from dbo.folder where FolderName='" + fname + "' and FolderId='" + pId + "'";
                MySqlCommand command1 = new MySqlCommand(query1, conn);
                MySqlDataReader temp1 = command1.ExecuteReader();
                if(temp1.Read() == true)
                {
                    res2 = true;
                }
                if (res1 == true || res2 == true || ((fname == "root") && (pId == 0))) 
                {
                    return true;
                }
                return false;
            }
        }
    }
}
