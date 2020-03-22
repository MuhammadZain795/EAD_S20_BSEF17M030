using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_DAL;

namespace UMS_BAL
{
    public static class userBO
    {
        public static Boolean loginEmailValidationForNew(String login, String email)
        {
            return userDAO.loginEmailValidationForNew(login,email);
        }
        public static Boolean loginEmailValidationForExisting(String login, String email,int ID)
        {
            return userDAO.loginEmailValidationForExisting(login, email,ID);
        }
        public static int insertUser(String name, String login, String pass, String email, String gender, String add, decimal age, String NIC, DateTime DOB, bool cri, bool hoc, bool chess, String image)
        {
            int res = userDAO.insertUser(name, login, pass, email, gender, add, age, NIC, DOB, cri, hoc, chess, image);
            return res;
        }
        public static void updateData(String name, String login, String pass, String email, String gender, String add, decimal age, String NIC, DateTime DOB, bool cri, bool hoc, bool chess, String image, int userID)
        {
            userDAO.updateData(name, login, pass, email, gender, add, age, NIC, DOB, cri, hoc, chess, image, userID);
        }
        public static userDAO.userData toEditData(String login, String pass)
        {
            return userDAO.toEditData(login, pass);
        }
        public static String username;
        public static String userpic;
        public static Boolean loginUser(String login, String pass)
        {
            Boolean res = userDAO.loginUser(login, pass);
            username = userDAO.username;
            userpic = userDAO.userpic;
            return res;
        }
    }
}
