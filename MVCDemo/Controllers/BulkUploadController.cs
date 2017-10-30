using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Filters;
using MVCDemo.ViewModels;
using MVCDemo.Models;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace MVCDemo.Controllers
{
    public class BulkUploadController : AsyncController {
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        //[AdminFilter]
        //public ActionResult Upload(FileUploadViewModel fileUpVM) {
        //    List<Employee> emps = GetEmployees(fileUpVM);
        //    var bal = new EmployeeBusinessLayer();
        //    bal.UploadEmployee(emps);
        //    return RedirectToAction("Index", "Employee");
        //}

        //异步方法
        [AdminFilter]
        public async Task<ActionResult> Upload(FileUploadViewModel fileUpVM) {
            //int t1 = Thread.CurrentThread.ManagedThreadId;  //获取线程id
            //异步执行
            List<Employee> emps = await Task.Factory.StartNew<List<Employee>>(
                    () => GetEmployees(fileUpVM)
                );

            //int t2 = Thread.CurrentThread.ManagedThreadId;  //获取线程id
            var bal = new EmployeeBusinessLayer();
            bal.UploadEmployee(emps);
            return RedirectToAction("Index", "Employee");
        }

        private List<Employee> GetEmployees(FileUploadViewModel fileUpVM) {
            var emps = new List<Employee>();
            StreamReader csvreader = new StreamReader(fileUpVM.FileUpload.InputStream);
            csvreader.ReadLine();
            while (!csvreader.EndOfStream) {
                string line = csvreader.ReadLine();
                string[] values = line.Split(',');
                Employee e = new Employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary = int.Parse(values[2]);
                emps.Add(e);
            }
            return emps;
        }
    }
}