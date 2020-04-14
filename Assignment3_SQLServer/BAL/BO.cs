using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BO
    {
        public static int insertUser(String name, String login, String pass)
        {
            return DAL.DAO.insertUser(name, login, pass);
        }
        public static Boolean loginUser(String login, String pass)
        {
            return DAL.DAO.loginUser(login, pass);
        }
    }
}
