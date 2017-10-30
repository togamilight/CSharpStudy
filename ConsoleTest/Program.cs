using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.格式化字符串
            Console.WriteLine("1.格式化字符串");
            Console.WriteLine("{0}+{1}={2}", 1, 2, 3);
            //标记可多次使用
            Console.WriteLine("{0}+{1}={0}", 1, 2);
            //但不可使用超出值列表长度的标记
            //Console.WriteLine("{0}+{1}={2}", 1, 2); //ERROR!

            //2.在字符串前加@
            Console.WriteLine("\n2.在字符串前加@");
            String str;
            //可以使编译器不识别转义字符
            str = @"Hello \n Word!";
            Console.WriteLine(str);
            //因此可以方便地定义路径字符串
            str = @"c:\user\test";
            Console.WriteLine(str);
            //还可以用来分行定义字符串
            str = @"Hello
                    World!";
            Console.WriteLine(str);
            //如果需要在字符串中显示一个双引号，则使用两个双引号
            str = @"""Hello World!""";
            Console.WriteLine(str);

            //3.加号连接数字与字符串时，得到字符串
            String str1 = "123"+456.7;
            Console.WriteLine("\n3.加号连接数字与字符串时，得到字符串\n" + str1);

            //行不通，不能通过foreach遍历String
            //string mystr = "helloworld!";
            //foreach(char c in mystr)
            //{
            //    console.write(c);
            //}

            //{index[, aligenment][:formatString]}
            //alignment:显示位数和对齐方式，负数右对齐，正数左对齐
            //formatString:格式化
            Console.WriteLine("{0, -4} {1, -4}\n{2, 4:F1} {3, 4:F1}", 12, 34, 6.3333, 8.3333);
            Console.ReadKey();
        }
    }
}
