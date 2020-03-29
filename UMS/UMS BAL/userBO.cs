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
        public static Boolean verifyAdmin(String login,String pass)
        {
            return userDAO.verifyAdmin(login, pass);
        }
        public static LinkedList<Int32> idList = new LinkedList<Int32>();
        public static LinkedList<String> nameList = new LinkedList<string>();
        public static LinkedList<String> loginList = new LinkedList<string>();
        public static LinkedList<String> addressList = new LinkedList<string>();
        public static LinkedList<Decimal> ageList = new LinkedList<Decimal>();
        public static void loadUsersData()
        {
            userDAO.loadUsersData();
            int count = userDAO.idList.Count;
            for (int i = 0; i < count; i++)
            {
                idList.AddLast(userDAO.idList.First.Value);
                userDAO.idList.RemoveFirst();
                nameList.AddLast(userDAO.nameList.First.Value);
                userDAO.nameList.RemoveFirst();
                loginList.AddLast(userDAO.loginList.First.Value);
                userDAO.loginList.RemoveFirst();
                addressList.AddLast(userDAO.addressList.First.Value);
                userDAO.addressList.RemoveFirst();
                ageList.AddLast(userDAO.ageList.First.Value);
                userDAO.ageList.RemoveFirst();
            }
        }
        public static String getMail(String login)
        {
            return userDAO.getMail(login);
        }
        public static void updatePass(String pass)
        {
            userDAO.getMail(pass);
        }
    }
}
