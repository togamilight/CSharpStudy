using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _014线程_任务
{
    class Program
    {
        static void ThreadMethod()
        {
            Console.WriteLine("线程开始：" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("线程结束：" + Thread.CurrentThread.ManagedThreadId);
        }
        static void FirstTask()
        {
            Console.WriteLine("do in " + Task.CurrentId);
            Thread.Sleep(2000);
        }
        //连续任务中，后面的任务必须带有Task参数
        static void SecondTask(Task task)
        {
            Console.WriteLine("do after " + task.Id);
            Console.WriteLine("do in " + Task.CurrentId);
            Thread.Sleep(2000); 
        }
        static void Main(string[] args)
        {
            //1.直接通过task来启动
            Task task = new Task(ThreadMethod);
            task.Start();

            //2.通过TaskFactory来启动
            //TaskFactory tf = new TaskFactory();
            //Task task = tf.StartNew(ThreadMethod);

            //连续任务，第一个任务执行完后，接着执行它后面的任务
            Task task1 = new Task(FirstTask);
            Task task2 = task1.ContinueWith(SecondTask);
            task1.Start();

            //在一个任务中再建一个子任务的话，父任务执行完后会等待子任务完成
            Console.ReadKey();

        }
    }
}
