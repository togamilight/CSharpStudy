using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            Exception e = new Exception("Invalid Controller or Action Name");
            HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
    }
}