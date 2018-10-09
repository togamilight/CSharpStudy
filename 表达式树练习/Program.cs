using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace 表达式树练习 {
    class Program {
        static void Main(string[] args) {
            //表达式树编译成委托
            ConstantExpression firstArg = Expression.Constant(2);
            ConstantExpression secondArg = Expression.Constant(3);
            BinaryExpression add = Expression.Add(firstArg, secondArg);
            Func<int> compiled = Expression.Lambda<Func<int>>(add).Compile();
            Console.WriteLine(add);
        }
    }
}
