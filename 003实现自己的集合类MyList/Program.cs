using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003实现自己的集合类MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            MyList<int> list = new MyList <int>();
            Console.WriteLine(list.Capacity);
            list.Add(4);
            list.Add(5);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            list.Add(4);
            list.Add(5);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            list.Add(4);
            list.Add(5);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            list.Capacity = 10;
            Console.WriteLine(list[1]);
            Console.WriteLine(list.Capacity);
            Console.ReadKey();
        }
    }
}
