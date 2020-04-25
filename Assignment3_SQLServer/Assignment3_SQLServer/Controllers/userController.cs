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
        //[ActionName("Login")]
        public JsonResult Login1(String login, String pass)
        {
            Object data = null;

            try
            {
                var url = "";
                var flag = false;

                var obj = BAL.BO.loginUser(login, pass);
                if (obj == true && login != "" && pass != "")
                {
                    flag = true;
                    Session["isValid"] = 1;
                        url = Url.Content("~/Home/Index");
                }

                data = new
                {
                    valid = flag,
                    urlToRedirect = url
                };
            }
            catch (Exception)
            {
                data = new
                {
                    valid = false,
                    urlToRedirect = ""
                };
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult newUser()
        {
            return View("newUser");
        }
        public JsonResult insertUser(String name, String login, String pass)
        {
            Object data = null;

            try
            {
                var url = "";
                var flag = false;

                var obj = BAL.BO.loginValidationForNew(login);
                if (obj == false && login != "" && pass != "" && name != "")
                {
                    flag = true;
                    Session["isValid"] = 1;
                    url = Url.Content("~/user/Login");
                }

                data = new
                {
                    valid = flag,
                    urlToRedirect = url
                };
            }
            catch (Exception)
            {
                data = new
                {
                    valid = false,
                    urlToRedirect = ""
                };
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getChildFolders(int pId)
        {
            var list = BAL.BO.getChildFolders(pId);
            var temp = new
            {
                data = list
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public static Boolean checkName(String fname, Int32 pId)
        {
            return BAL.BO.checkName(fname, pId);
        }
        [HttpPost]
        public JsonResult createFolder(String folderName, Int32 parentId)
        {
            if (checkName(folderName, parentId) == false)
            {
                BAL.BO.createFolder(folderName, parentId);
                var h = new
                {
                    msg = "Succesfull Created"
                };
                return Json(h, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var h = new
                {
                    msg = "sameNameNotAllowed"
                };
                return Json("sameNameNotAllowed", JsonRequestBehavior.AllowGet);
            }

            
        }
    }
}