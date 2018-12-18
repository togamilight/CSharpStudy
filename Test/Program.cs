using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test {
    class Program {
        static void Main(string[] args) {
            //Expression firstArg = Expression.Constant(2);
            //Expression secondArg = Expression.Constant(3);
            //Expression add = Expression.Add(firstArg, secondArg);

            //Func<int> compiled = Expression.Lambda<Func<int>>(add).Compile();
            //Console.WriteLine(add);

            //    MethodInfo method = typeof(string).GetMethod("StartsWith",
            //new[] { typeof(string) });
            //    var target = Expression.Parameter(typeof(string), "x");
            //    var methodArg = Expression.Parameter(typeof(string), "y");

            //    Expression call = Expression.Call(target, method, new[] { methodArg });
            //    var lambdaParameters = new[] { target, methodArg };
            //    var lambda = Expression.Lambda<Func<string, string, bool>>(call, lambdaParameters);
            //    var compiled = lambda.Compile();
            //    Console.WriteLine(compiled("First", "Fir"));

            TestAnonmyList();

            Console.ReadKey();
        }

        //测试泛型匿名类型创建
        static IList TestAnonmyList() {
            var obj = new { a = "1", b = 2, c = 3.0 };
            Type type = typeof(List<>).MakeGenericType(obj.GetType());
            var list = Activator.CreateInstance(type) as IList;
            list.Add(obj);
            return list;
        }
    }
}
