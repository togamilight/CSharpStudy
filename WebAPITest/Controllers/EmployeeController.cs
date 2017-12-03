using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    public class EmployeeController : ApiController
    {
        public Employee GET() {
            Employee e = new Employee() {
                FirstName = "Sukesh",
                LastName = "Marla",
                Salary = 25000
            };
            return e;
        }
    }
}
