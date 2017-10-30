using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020自定义类型转换 {
    class Program {
        static void Main(string[] args) {
            Stone stone = new Stone(500);
            Monkey monkey = (Monkey)stone;
            Console.WriteLine(monkey.age.ToString());

            Console.ReadKey();
        }
    }

    class Stone {
        public int age;
        public Stone(int age) {
            this.age = age;
        }

        //在被转换的类中定义，explicit为显式，implicit为隐式
        public static explicit operator Monkey(Stone stone) {
            Monkey m = new Monkey(stone.age / 5);
            return m;
        }
    }

    class Monkey {
        public int age;
        public Monkey(int age) {
            this.age = age;
        }
    }
}
