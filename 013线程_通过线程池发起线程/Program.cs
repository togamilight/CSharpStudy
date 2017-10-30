using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _013线程_通过线程池发起线程
{
    class Program
    {
        static void ThreadMethod(object state)
        {
            Console.WriteLine("线程开始：" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("线程结束：" + Thread.CurrentThread.ManagedThreadId);
        }
        static void Main(string[] args)
        {
            //加入线程池的方法必须有一个object参数
            //线程池里的都是后台线程，也不能修改优先级。只适合执行小任务
            //新建工作线程
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            Console.ReadKey();
        }
    }
}
