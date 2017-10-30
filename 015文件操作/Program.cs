using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015文件操作
{
    class Program
    {
        static void Main(string[] args)
        {
            //文件操作FileInfo类
            //相对路径下的这个文件实际是位于工程目录下的bin/debug/下面
            FileInfo fileInfo = new FileInfo("test.txt");
            if (fileInfo.Exists == false)
            {
                fileInfo.Create();
                Console.WriteLine("创建文件：" + fileInfo.Name);
            }
            Console.WriteLine("文件大小(字节):" + fileInfo.Length);

            //文件夹操作，DirectoryInfo
            //.为当前文件夹，..为上一个文件夹，/为根目录
            DirectoryInfo dirInfo = new DirectoryInfo(".");
            Console.WriteLine("文件夹名：" + dirInfo.Name);
            Console.WriteLine("父文件夹：" + dirInfo.Parent);
            Console.WriteLine("根目录（盘符）：" + dirInfo.Root);
            //dirInfo.CreateSubdirectory("test/test1");   //创建子文件夹
            Console.ReadKey();
        }
    }
}
