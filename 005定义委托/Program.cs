using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005定义委托
{
    public delegate void display(string s);
    class Program
    {
        public static void show(object o)
        {
            Console.WriteLine("Hello World!");
        }

        public static void show1(string s) {
            Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            
            //初始化委托
            //display display2 = new display(show);
            display display1 = show;
            display display2 = show1;

            Console.WriteLine("d1before:"+display1.GetHashCode());

            display1 += display2;
            display display3 = Delegate.Combine(display1, display2) as display;
            Console.WriteLine("d1after:" + display1.GetHashCode());
            display display4 = Delegate.Remove(display3, display1) as display;
            //执行委托
            //display2.Invoke();
            //display1("");
            display1("1");
            display3("3");
            display4("4");
            Console.ReadKey();
        }
    }
}
