using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型练习 {
    class Program {
        static void Main(string[] args) {
            //Add(1, "xc");
            //TestClass<int, int> test1 = new TestClass<int, int>();
            //test1.Add(1, 2);
            Type type = typeof(List<>);
            Type type1 = type.GetGenericTypeDefinition();
            Type type2 = type.MakeGenericType();
            Console.WriteLine("Type1Name:" + type1.Name);
            Console.ReadKey();
        }

        static T Add<T, V>(T a, V b) where T : class where V : struct{
            return  a;
        }
    }

    class TestClass<T, V> {

        public void Add(T a, V b) {

        }

        //当传入的T,V相同时具有二义性，编译不通过
        //public void Add(V a, T b) {

        //}

        //当传入的泛型使泛型方法与普通方法类型相同时，普通方法会覆盖泛型方法
        public void Add(int a, int b) {
            Console.WriteLine(a + b);
        }
    }

    interface Interface1<T> {
        void show();
    }

    class Class1<T> : Interface1<T> {
        public void show() {

        }
    }
}
