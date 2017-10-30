using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCDemo.Validations;

namespace MVCDemo.Models {
    public class Employee {
        [Key]
        public int EmployeeId { get; set; }
        //[Required(ErrorMessage = "Enter First Name")]
        [FirstNameValidation]
        public string FirstName { get; set; }
        [StringLength(5, /*MinimumLength = 2,*/ ErrorMessage = "Last Name length should not be greater than 5")]
        public string LastName { get; set; }
        public int? Salary { get; set; }  

        public Employee(string fn, string ln, int sal) {
            FirstName = fn;
            LastName = ln;
            Salary = sal;
        }

        public Employee() {

        }
    }
}