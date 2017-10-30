using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006冒泡排序拓展_委托
{
    class Program
    {
        public static void CommonSort<T>(T[] array, Func<T, T, bool> CompareMethod)
        {
            //标记是否交换过
            bool swapped;
            //冒泡排序
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (CompareMethod(array[i], array[i + 1]))
                    {
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        static void Main(string[] args)
        {
            Employee[] eArray = new Employee[] { new Employee("a", 20), new Employee("b", 90), new Employee("c", 10), new Employee("d", 30), new Employee("e", 50), new Employee("f", 20), new Employee("g", 40), new Employee("h", 70), new Employee("i", 80), };

            CommonSort(eArray, Employee.Compare);

            foreach(Employee e in eArray)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
