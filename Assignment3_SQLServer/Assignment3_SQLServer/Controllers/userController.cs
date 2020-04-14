using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3_SQLServer.Controllers
{
    public class userController : Controller
    {
        // GET: user
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Error = TempData["Msg"];
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login1(String login, String pass)
        {
            //String login = Request["Login"];
            //String pass = Request["Pass"];
            if (BAL.BO.loginUser(login,pass) == true)
            {
                Session["isValid"] = 1;
                return Redirect("~/Home/Index");
            }
            else
            {
                ViewBag.Login = login;
                ViewBag.Error = "Invalid";
                return View("Login");
            }
        }
        public ActionResult newUser()
        {
            return View("newUser");
        }
        public void insertUser(String name, String login, String pass)
        {
            BAL.BO.insertUser(name, login, pass);
        }
    }
}