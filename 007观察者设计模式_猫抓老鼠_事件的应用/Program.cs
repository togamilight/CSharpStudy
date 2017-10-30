using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007观察者设计模式_猫抓老鼠_事件的应用
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("Tom");
            Mouse m1 = new Mouse("Jerry", cat);
            Mouse m2 = new Mouse("Micky", cat);
            Mouse m3 = new Mouse("Mini", cat);
            cat.CatComing();
            Console.ReadKey();
        }
    }
}
