using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _011线程_通过委托发起线程
{
    class Program
    {
        static int Test(int i, string s)
        {
            Thread.Sleep(100);     //休眠
            Console.WriteLine("helloworld "+i+s);
            return i;
        }
        static void Main(string[] args)
        {
            Func<int, string, int> a = Test;
            //开启线程,方法的参数写在最前面
            //返回值为IAsyncResult类型,表示当前函数的执行状态
            //IAsyncResult ar =  a.BeginInvoke(100, "!", null, null);

            //检测线程结束的3种方法
            //1.当线程为完成时循环打印.
            //while (ar.IsCompleted == false)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(10);
            //}
            //得到方法的返回值
            //int res = a.EndInvoke(ar);
            //Console.WriteLine(res);

            //2.通过等待句柄判断
            //参数表示超时时间，如果超出时间线程仍未结束，返回false
            //bool isEnd = ar.AsyncWaitHandle.WaitOne(1000);
            //if (isEnd)
            //{
            //    //得到方法的返回值
            //    int res = a.EndInvoke(ar);
            //    Console.WriteLine(res);
            //}

            //3.通过回调函数判断
            //开启线程,方法的参数写在最前面
            //倒数第二个参数为回调函数的委托，回调函数会在线程结束后执行
            //最后一个参数为要传给回调函数的参数,可以在回调函数中通过ar.AsyncState取得,取得时需强制转换类型
            //返回值为IAsyncResult类型,表示当前函数的执行状态
            //IAsyncResult ar =  a.BeginInvoke(100, "!", OnCallBack, a);

            //Lambda表达式
            a.BeginInvoke(100, "!", ar =>
            {
                //取得开启线程的方法的返回值
                //Lamba表达式中，a可直接从上下文取得x
                var res = a.EndInvoke(ar);
                Console.WriteLine("Thread is end!" + res);
            }, null);
            Console.ReadKey();
        }

        //将作为线程结束时的回调函数，参数必须为IAsyncResult
        static void OnCallBack(IAsyncResult ar)
        {
            //取得BeginInvoke传来的最后一个参数
            var a = ar.AsyncState as Func<int, string, int>;
            //取得开启线程的方法的返回值
            var res = a.EndInvoke(ar);
            Console.WriteLine("Thread is end!" + res);
        }
    }
}
