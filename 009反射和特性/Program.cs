using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _009反射和特性
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass item1 = new MyClass();
            //用GetType()获得item1的Type对象
            Type type = item1.GetType();    //type对象中存放的是该类的成员，与对象无关
            Console.WriteLine("类名：" + type.Name);   //获取类名
            Console.WriteLine("命名空间：" + type.Namespace);   //获取类所在的命名空间
            Console.WriteLine("程序集：" + type.Assembly);   //获取类所在的程序集

            //FieldInfo位于命名空间System.Reflection下
            //获取类的public字段
            FieldInfo[] fieldArray = type.GetFields();
            Console.Write("public字段：");
            foreach (var info in fieldArray)
                Console.Write(info.Name + " "); //打印字段名
            Console.WriteLine();

            //获取类的public属性
            PropertyInfo[] propertyArray = type.GetProperties();
            Console.Write("public属性：");
            foreach (var info in propertyArray)
                Console.Write(info.Name + " "); //打印属性名
            Console.WriteLine();

            //获取类的public方法，包括属性的get/set方法，从父类继承来的方法
            MethodInfo[] methodArray = type.GetMethods();
            Console.Write("public方法：");
            foreach (var info in methodArray)
                Console.Write(info.Name + " "); //打印方法名
            Console.WriteLine();

            //通过type获取程序集
            Assembly assem = type.Assembly;
            Console.WriteLine("程序集：" + assem.FullName);
            //通过程序集获取该程序集中的所有类型
            Type[] types = assem.GetTypes();
            Console.Write("程序集内类型：");
            foreach (var t in types)
                Console.Write(t.Name + " ");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
