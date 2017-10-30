using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _012通过Thread类创建线程
{
    class Program
    {
        //要作为新线程运行的函数有参数的话必须为Object类型,且最多只能有一个参数
        static void Download(Object s)
        {
            //通过Thread.CurrentThread.ManagedThreadId获得当前线程id
            Console.WriteLine(s+"DownloadStart:"+Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine(s+"DownloadEnd:" + Thread.CurrentThread.ManagedThreadId);
        }
        static void Main(string[] args)
        {
            //1.通过Thread类创建静态方法的线程
            //Thread thread = new Thread(Download);
            //thread.Start("种子");

            //2.通过Thread类创建某个类（对象）的方法的线程
            MyThread my = new MyThread("种子", "xxx.torrent");
            Thread thread = new Thread(my.Download);
            thread.Start();
            Console.WriteLine("Main");
            Console.ReadKey();
        }
    }
}
