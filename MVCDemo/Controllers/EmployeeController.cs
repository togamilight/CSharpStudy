using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
using MVCDemo.ViewModels;
using MVCDemo.Filters;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public string GetString() {
            return "HelloWorld!";
        }

        [Authorize]
        [HeaderFooterFilter]
        public ActionResult Index() {
            //Employee emp = new Employee("Joster", "Joseff", 15000);
            //ViewData["Employee"] = emp;
            //ViewBag.Employee = emp;
            //return View("MyIndex");
            //return View("MyIndex", emp);

            //使用ViewModel层从Model封装出适合View的数据，再用一层将其封装成一个List，使用业务层获取数据
            var empListViewModel = new EmployeeListViewModel();
            var empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();
            var empViewModels = new List<EmployeeViewModel>();
            //将每个Model封装成ViewModel
            foreach (var emp in employees) {
                var empVM = new EmployeeViewModel();
                empVM.EmployeeName = emp.FirstName + " " + emp.LastName;
                empVM.Salary = emp.Salary.Value.ToString("C");
                if(emp.Salary > 15000) {
                    empVM.SalaryColor = "yellow";
                }else {
                    empVM.SalaryColor = "green";
                }
                empViewModels.Add(empVM);
            }
            empListViewModel.Employees = empViewModels;
            return View("MyIndex2", empListViewModel);     //用于List强类型的View
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew() {
            var createEmpVM = new CreateEmployeeViewModel();
            return View("CreateEmployee2", createEmpVM);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SaveEmployee(Employee e, string BtnSubmit){
            switch (BtnSubmit) {
                case "Save Employee":
                    //return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                    if (ModelState.IsValid) {
                        var empBL = new EmployeeBusinessLayer();
                        empBL.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }else {
                        var vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary.HasValue) {
                            vm.Salary = e.Salary.ToString();
                        }else {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee2", vm);
                    }
                    
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        public ActionResult GetAddNewLink() {
            if (Convert.ToBoolean(Session["IsAdmin"])) {
                return PartialView("AddNewLink");
            }
            return new EmptyResult();
        }

        //public string Show(string id1, string id2, string id3) {
        //    return id1 + "/" + id2 + "/" + id3;
        //}

        //public Customer GetCustomer() {
        //        Customer c = new Customer();
        //        c.CustomerName = "JoJo";
        //        c.Address = "1";
        //        return c;
        //    }
    }

    //public class Customer {
    //    public string CustomerName { get; set; }
    //    public string Address { get; set; }
    //    public override string ToString() {
    //        return CustomerName + "|" + Address;
    //    }
    //}

}