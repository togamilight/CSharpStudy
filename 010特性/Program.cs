#define isTest //定义该字符串的宏
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _010特性
{
    [MyTest("program类", Version = "1")]    //使用时不用加上后面的Attribute
    class Program
    {
        //[Obsolete]用于提示一个方法已过时，调用时会弹出警告
        //括号内可填提示信息
        //true参数表示将提示错误而不是警告
        [Obsolete("建议使用新方法NewMethod代替", true)]
        static void OldMethod() { Console.WriteLine("旧方法，建议使用新方法代替"); }
        static void NewMethod() { Console.WriteLine("新方法"); }

        //Conditional位于命名空间System.Diagnostics下
        //用于标记使一个方法不会被调用
        //字符串为任意字符串，当定义了该字符串的宏时，方法才会被调用
        //例如，当#define isTest时，这个方法才会被调用
        [Conditional("isTest")]
        static void Test1() { Console.WriteLine("test1"); }
        static void Test2() { Console.WriteLine("test2"); }

        //这3个特性位于System.Runtime.CompilerServices
        static void PrintOut(String str, [CallerFilePath]String fileName="", [CallerLineNumber]int lineNum=0, [CallerMemberName]String methodName="")
        {
            Console.WriteLine(str);
            Console.WriteLine("调用者文件名："+fileName);
            Console.WriteLine("调用位置（行数）："+lineNum);
            Console.WriteLine("调用方法名："+methodName);
        }
        static void Main(string[] args)
        {
            //OldMethod();
            Test1();
            Test2();
            Test1();
            PrintOut("123");

            //取得type对象的另一种方法，通过typeof(类名)获取
            Type type = typeof(Program);
            Object[] arrayAttri = type.GetCustomAttributes(false);   //false表示不从其父类中寻找
            MyTestAttribute myTA = arrayAttri[0] as MyTestAttribute;    //强制类型转换
            Console.WriteLine(myTA.Description + " " + myTA.Version);
            Console.ReadKey();
        }
    }
}
