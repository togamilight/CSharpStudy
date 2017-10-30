using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _012通过Thread类创建线程
{
    class MyThread
    {
        private String fileName;
        private String filepath;
        public MyThread(string fileName, string filepath) {
            this.fileName = fileName;
            this.filepath = filepath;
        }

        public void Download()
        {
            //通过Thread.CurrentThread.ManagedThreadId获得当前线程id
            Console.WriteLine(fileName + "|" + filepath + "| DownloadStart:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine(fileName + "|" + filepath + "| DownloadEnd:" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
