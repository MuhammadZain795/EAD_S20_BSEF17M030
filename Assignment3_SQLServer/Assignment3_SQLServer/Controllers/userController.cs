﻿using System;
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
        public ActionResult insertUser(String name, String login, String pass)
        {
            if (!(BAL.BO.loginValidationForNew(login)))
            {
                BAL.BO.insertUser(name, login, pass);
                Session["isValid"] = 1;
                return Redirect("~/Home/Index");
            }
            else
            {
                ViewBag.name = name;
                ViewBag.login = login;
                ViewBag.Error = "Login is already taken.";
                return View("newUser");
            }
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
        //[HttpPost]
        //public void createFolder(String folderName, Int32 parentId)
        //{
        //    BAL.BO.createFolder(folderName, parentId);
        //}
        [HttpPost]
        public JsonResult createFolder(String folderName, Int32 parentId)
        {
            BAL.BO.createFolder(folderName, parentId);
            var h = new
            {
                msg = "Succesfull Created"
            };
            return Json(h, JsonRequestBehavior.AllowGet);
        }
    }
}