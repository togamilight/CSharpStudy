using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
using MVCDemo.ViewModels;
using System.Web.Security;

namespace MVCDemo.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login()
        {
            return View("LoginView");
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails u) {
            if (ModelState.IsValid) {
                var bal = new EmployeeBusinessLayer();
                UserStatus userStatus = bal.GetUserValidity(u);
                bool isAdmin = false;
                if(userStatus == UserStatus.AuthenticatedAdmin) {
                    isAdmin = true;
                }else if(userStatus == UserStatus.NonAuthenticatedUser) {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("LoginView");
                }

                //为提供的用户名创建一个身份验证cookie，false表示非持久性cookie
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["IsAdmin"] = isAdmin;
                return RedirectToAction("Index", "Employee");
                //if (bal.IsValidUser(u)) {
                //    //为提供的用户名创建一个身份验证cookie，false表示非持久性cookie
                //    FormsAuthentication.SetAuthCookie(u.UserName, false);
                //    return RedirectToAction("Index", "Employee");
                //}
                //else {
                //    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                //    return View("LoginView");
                //}
            }
            else {
                return View("LoginView");
            }
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return View("LoginView");
        }
    }
}