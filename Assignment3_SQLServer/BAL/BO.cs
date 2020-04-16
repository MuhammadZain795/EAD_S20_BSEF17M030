using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BO
    {
        public static void insertUser(String name, String login, String pass)
        {
            DAL.DAO.insertUser(name, login, pass);
        }
        public static Boolean loginUser(String login, String pass)
        {
            return DAL.DAO.loginUser(login, pass);
        }
        public static Boolean loginValidationForNew(String login)
        {
            return DAL.DAO.loginValidationForNew(login);
        }
        public static List<folderData> getChildFolders(int pId)
        {
            return DAL.DAO.getChildFolders(pId);
        }
        public static void createFolder(String folderName, Int32 parentId)
        {
            DAL.DAO.createFolder(folderName, parentId);
        }
        public static Boolean checkName(String fname, Int32 pId)
        {
            return DAL.DAO.checkName(fname, pId);
        }
    }
}
