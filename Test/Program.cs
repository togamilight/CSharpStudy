using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test {
    class Program {
        //delegate void MyDelegate(string a, string b); 
        //static void Test1() {

        //}
        //static void Test1(int a) {

        //}
        //static void Test1(object a, object b) {
        //}
        static void Main(string[] args) {
            //Action<int> act1 = Test1;
            //Action<string, string> act2 = Test1;
            //MyDelegate myd = Test1;
            //Thread thread = new Thread(Test1);
            //Delegate d = (ThreadStart)Test1;
            //TestFinally("");

            //Foo f = new Foo(1);
            //Console.WriteLine(f.Value);
            //Trans trans = new Trans() { Position = { x = 1, y = 2 } };

            var tom = new { Name = "Tom", Age = 9, T = 2.0};
            Console.WriteLine("tom's type name:"+ tom.GetType().Name);
            Console.ReadKey();
        }

        public struct Foo {
            public int Value { get; private set; }
            public Foo(int value){
                this.Value = value;
            }
        }

        public class Pos {
            public int x;
            public int y;
            public readonly int z;
        }

        public class Trans {
            //public Pos Position { get; set; }
            public readonly Pos Position;
        }
        //static void TestFinally(object o) {
        //    try {
        //        int a = (int)o;
        //        if (a == 1)
        //            return;
        //    }
        //    catch {
        //        Console.WriteLine("Catch");
        //        return;
        //    }
        //    finally {
        //        Console.WriteLine("Finally");
        //    }
        //}
    }
}
