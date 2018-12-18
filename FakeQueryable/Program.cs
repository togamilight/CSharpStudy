using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FakeQueryable
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from x in new FakeQuery<string>()
                        where x.StartsWith("abc")
                        select x.Length;
            foreach (int i in query) { }

            foreach (var x in new FakeQuery<string>()) { }
            Console.ReadKey();
        }
    }

    class FakeQuery<T> : IQueryable<T>
    {
        public Expression Expression { get; private set; }
        public IQueryProvider Provider { get; private set; }
        public Type ElementType { get; private set; }

        internal FakeQuery(IQueryProvider provider, Expression expression) {
            Expression = expression;
            Provider = provider;
            ElementType = typeof(T);
        }

        internal FakeQuery() : this(new FakeQueryProvider(), null) {
            //使用这个查询作为初始表达式，当不使用任何查询操作符时，也能返回原数据表
            Expression = Expression.Constant(this); 
        }

        public IEnumerator<T> GetEnumerator() {
            Console.WriteLine("FakeQuery: " + Expression.ToString());
            //返回空结果序列，生产环境代码应该在这解析表达式,调用Provider上的Execute方法，返回结果
            return Enumerable.Empty<T>().GetEnumerator();   
        }

        IEnumerator IEnumerable.GetEnumerator() {
            Console.WriteLine("FakeQuery: " + Expression.ToString());
            //返回空结果序列，生产环境代码应该在这解析表达式,调用Provider上的Execute方法，返回结果
            return Enumerable.Empty<T>().GetEnumerator();
        }
    }

    class FakeQueryProvider: IQueryProvider {
        public IQueryable<T> CreateQuery<T>(Expression expression) {
            Console.WriteLine("FakeQueryProvider: " + expression.ToString());
            return new FakeQuery<T>(this, expression);
        }

        public IQueryable CreateQuery(Expression expression) {
            Type queryType = typeof(FakeQuery<>).MakeGenericType(expression.Type);
            object[] constructorArgs = new object[] { this, expression };
            return (IQueryable)Activator.CreateInstance(queryType, constructorArgs);
        }

        public T Execute<T>(Expression expression) {
            Console.WriteLine("FakeQueryProvider: " + expression.ToString());
            return default(T);
        }

        public object Execute(Expression expression) {
            Console.WriteLine("FakeQueryProvider: " + expression.ToString());
            return null;
        }
    }
}