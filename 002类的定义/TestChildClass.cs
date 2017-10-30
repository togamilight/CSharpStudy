using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002类的定义 {
    class TestChildClass : TestBaseClass{
        public new void Test() {
            Console.WriteLine("ChildTest!");
        }
        public void Test_1() {
            Console.WriteLine("Test_1");
        }
    }
}
