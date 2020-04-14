using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3_SQLServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var s = Session["isValid"];
            if (s != null)
            {
                return View();
            }
            else
            {
                TempData["Msg"] = "Unauthorized Access";
                return Redirect("~/user/Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}