using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002类的定义 {
    //参数逆变性和返回值协变性
    interface MyInterface {
        object TestMethod1(string s);
    }
    class Test2 : MyInterface {
        object MyInterface.TestMethod1(string o) {
            return TestMethod1(o);
        }

        public string TestMethod1(object o) {
            return "";
        }
    }
}
