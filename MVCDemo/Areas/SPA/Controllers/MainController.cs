using MVCDemo.ViewModels.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.ViewModels;
using SPAVM = MVCDemo.ViewModels.SPA;
using MVCDemo.Models;
using MVCDemo.Filters;

namespace MVCDemo.Areas.SPA.Controllers
{
    public class MainController : Controller
    {
        // GET: SPA/Main
        public ActionResult Index()
        {
            var mainVM = new MainViewModel() {
                UserName = User.Identity.Name,
                FooterData = new FooterViewModel() {
                    CompanyName = "ABCompany",
                    Year = DateTime.Now.Year.ToString()
                }
            };
            return View("Index", mainVM);
        }

        public ActionResult EmployeeList() {
            var empListVM = new SPAVM.EmployeeListViewModel();
            var empBal = new EmployeeBusinessLayer();
            List<Employee> emps = empBal.GetEmployees();
            var empVMs = new List<SPAVM.EmployeeViewModel>();

            foreach(var emp in emps) {
                var empVM = new SPAVM.EmployeeViewModel() {
                    EmployeeName = emp.FirstName + " " + emp.LastName,
                    Salary = emp.Salary.Value.ToString("C")
                };
                if(emp.Salary > 15000) {
                    empVM.SalaryColor = "yellow";
                }else {
                    empVM.SalaryColor = "green";
                }
                empVMs.Add(empVM);
            }
            empListVM.Employees = empVMs;
            return View("EmployeeList", empListVM);
        }

        public ActionResult GetAddNewLink() {
            if (Convert.ToBoolean(Session["IsAdmin"])) {
                return PartialView("AddNewLink");
            }else {
                return new EmptyResult();
            }
        }

        [AdminFilter]
        public ActionResult AddNew() {
            var createEmpVM = new SPAVM.CreateEmployeeViewModel();
            return PartialView("CreateEmployee", createEmpVM);
        }

        [AdminFilter]
        public ActionResult SaveEmployee(Employee emp) {
            var empBal = new EmployeeBusinessLayer();
            empBal.SaveEmployee(emp);

            var empVM = new SPAVM.EmployeeViewModel() {
                EmployeeName = emp.FirstName + " " + emp.LastName,
                Salary = emp.Salary.Value.ToString("C")
            };
            if (emp.Salary > 15000) {
                empVM.SalaryColor = "yellow";
            }
            else {
                empVM.SalaryColor = "green";
            }
            return Json(empVM);
        }
    }
}