using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021接口 {
    interface MyInterface {
        void Show();
    }

    class MyClass : MyInterface {
        void MyInterface.Show() {
            Console.WriteLine("IShow");
            Show();
        }

        public string Show() {
            Console.WriteLine("CShow");
            return "s";
        }
    }
    class Program {
        static void Main(string[] args) {
            //MyClass myInterface = new MyClass();
            MyInterface myInterface = new MyClass();
            myInterface.Show();
            Console.ReadKey();
            Func<int, int> func = delegate(int a) {
                return a;
            };
        }
    }
}
