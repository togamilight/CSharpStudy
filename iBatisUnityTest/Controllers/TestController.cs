using iBatisUnityTest.Dao;
using iBatisUnityTest.DataMapper;
using iBatisUnityTest.Models;
using iBatisUnityTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iBatisUnityTest.Controllers
{
    public class TestController : Controller
    {
        public ITestUserService UserService { get; set; }
        public ActionResult AddUser()
        {
            TestUser user = new TestUser()
            {
                Name = "zhb",
                DateTime = DateTime.Now
            };
            int id = UserService.AddUser(user);
            return Content("添加成功,id："+id);
        }

        public ActionResult GetUser()
        {
            IList<TestUser> users = UserService.GetAllUserBySql("");
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteUser()
        {
            IList<TestUser> users = UserService.GetAllUserBySql("");
            int id = UserService.DeleteUser(users.FirstOrDefault());
            return Content("删除成功,id：" + id);
        }
        
        public ActionResult UpdateUser()
        {
            IList<TestUser> users = UserService.GetAllUserBySql("");
            TestUser user = users.FirstOrDefault();
            user.Name = "dio";
            int id = UserService.UpdateUser(user);
            return Content("修改成功,id：" + id);
        }
    }
}