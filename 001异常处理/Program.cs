using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001异常处理
{
    class Program
    {
        static void Main(string[] args)
        {
            //try必须为1个，catch为0到多个，finally为0到1个，catch和finally至少有1个
            try
            {
                int[] array = { 1, 2, 3 };
                array[4] = 4;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("出现数组下标越界异常");
            }
            //不加括号和参数时捕获所有异常
            catch
            {
                Console.WriteLine("出现异常");
            }
            finally
            {
                Console.WriteLine("异常处理完毕");
            }
            Console.ReadKey();
        }
    }
}
