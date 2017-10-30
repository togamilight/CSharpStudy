using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;
using MVCDemo.DataAccessLayer;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace MVCDemo.ViewModels {
    /// <summary>
    /// Employee的业务逻辑层
    /// </summary>
    public class EmployeeBusinessLayer {
        public List<Employee> GetEmployees() {
            //List<Employee> employees = new List<Employee>();
            //Employee emp = new Employee("Jostar", "Jolin", 20000);
            //employees.Add(emp);
            //return employees;

            //利用数据访问层得到数据
            var salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e) {
            var salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        //public bool IsValidUser(UserDetails u) {
        //    if (u.UserName == "Admin" && u.Password == "Admin")
        //        return true;
        //    return false;
        //}

        public UserStatus GetUserValidity(UserDetails u) {
            if(u.UserName == "Admin" && u.Password == "Admin") {
                return UserStatus.AuthenticatedAdmin;
            }

            if(u.UserName == "JoJo" && u.Password == "JoJo") {
                return UserStatus.AuthenticatedUser;
            }

            return UserStatus.NonAuthenticatedUser;
        }

        public void UploadEmployee(List<Employee> emps) {
            var salesDAL = new SalesERPDAL();
            salesDAL.Employees.AddRange(emps);
            try {
                salesDAL.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                foreach (var validationErrors in dbEx.EntityValidationErrors) {
                    foreach (var validationError in validationErrors.ValidationErrors) {
                        Debug.Write(string.Format("Class: {0}, Property: {1}, Error: {2}", 
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage), "error");
                    }
                }
                throw;
            }

        }
    }
}