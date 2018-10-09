using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoObjects连接练习 {
    class Program {
        static void Main(string[] args) {
            var watch = new Stopwatch();

            var enum1 = MyEnumerator1();
            var enum2 = MyEnumerator2();

            watch.Restart();
            var r2 = (from e2 in enum2
                     join e1 in enum1
                     on e2.b equals e1.b
                     select new { e2, e1 }).ToList();
            watch.Stop();
            Console.WriteLine("大左小右，耗时：" + watch.ElapsedMilliseconds + " 毫秒");

            watch.Restart();
            var r1 = (from e1 in enum1
                      join e2 in enum2
                      on e1.b equals e2.b
                      select new { e1, e2 }).ToList();
            watch.Stop();
            Console.WriteLine("小左大右，耗时：" + watch.ElapsedMilliseconds + " 毫秒");

            Console.ReadLine();
        }

        static IEnumerable<dynamic> MyEnumerator1() {
            var random = new Random();
            int i = 0;
            while (i < 1000) {
                yield return new { a = i++, b = random.Next(0, 1000)};
            }
        }

        static IEnumerable<dynamic> MyEnumerator2() {
            var random = new Random();
            int i = 0;
            while (i < 10000000) {
                yield return new { a = i++, b = random.Next(0, 1000) };
            }
        }
    }
}
