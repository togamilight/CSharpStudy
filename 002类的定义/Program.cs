using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002类的定义
{
    class Program
    {
        static void Main(string[] args)
        {
            //Character myCharacter1 = new Character();
            //myCharacter1.show();

            //Character player = new Player();
            //player.show();

            //Test test = new Test(1, 2, "abc");
            //Test1 test1 = new Test1();
            //test1.Test = test;
            //Console.WriteLine(test1.Test.a + " " + test1.Test.b + " " + test1.Test.s);
            //test1.Test.a = 2;
            //Console.WriteLine(test1.Test.a + " " + test1.Test.b + " " + test1.Test.s);

            MyClass1 class2of1 = new MyClass2();
            class2of1.Show();
            Console.ReadKey();
        }
    }

    interface MyInterface2 {
        void Show();
    }

    abstract class MyClass1{
        public virtual void Show() {
            Console.WriteLine("Class1");
        }
    }

    class MyClass2 : MyClass1{
        public new void Show() {
            Console.WriteLine("Class2");
        }
    }

    class MyClass3 : MyInterface2 {
        public void Show() {

        }
    }
}
