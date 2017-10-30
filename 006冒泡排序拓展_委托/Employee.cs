using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006冒泡排序拓展_委托
{
    class Employee
    {
        public String Name { get; private set; }
        public int Salary { get; private set; }

        public Employee(String name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return "N:" + Name + "    S:" + Salary;
        }

        public static bool Compare(Employee e1, Employee e2)
        {
            if (e1.Salary > e2.Salary) return true;
            else return false;
        }
    }
}
