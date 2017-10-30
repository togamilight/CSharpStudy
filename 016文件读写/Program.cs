using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016文件读写
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.用File类进行文件读写
            string[] strs1 = File.ReadAllLines("test1.txt"); //读取所有行,返回字符串数组
            string str1 = File.ReadAllText("test1.txt");     //读取所有行，返回字符串，带换行符
            byte[] bytes = File.ReadAllBytes("test1.txt");  //读取所有字节，字节是0~255的数
            Console.WriteLine("test1:\n" + str1);

            File.WriteAllLines("test2.txt", strs1); //创建或覆盖文件，写入传入的数组
            string str2 = File.ReadAllText("test2.txt"); 
            Console.WriteLine("test2:\n" + str2);

            File.WriteAllText("test3.txt", "hello"+Environment.NewLine+"world");   //创建或覆盖文件，写入传入的字符串, Environment.NewLine是当前系统的换行符，windows为\r\n,UNIX为\n
            string str3 = File.ReadAllText("test3.txt"); 
            Console.WriteLine("test3:\n" + str3);

            File.WriteAllBytes("test4.txt", bytes); //创建或覆盖文件，写入传入的字节数组
            string str4= File.ReadAllText("test4.txt");     //读取所有行，返回字符串，带换行符
            Console.WriteLine("test4:\n" + str4);

            //2.使用FileStream读写文件
            FileStream readStream = new FileStream("a.jpg", FileMode.Open); //打开一个文件，得到流
            FileStream writeStream = new FileStream("b.jpg", FileMode.Create); //创建一个文件，得到流
            Byte[] data = new Byte[1024];
            while(true){    //从旧文件中读取字节到data中，再写入新文件，完成复制
                int length = readStream.Read(data, 0, data.Length);
                if(length == 0)
                {
                    Console.WriteLine("复制完毕！");
                    break;
                }
                writeStream.Write(data, 0, length);
                Console.Write(".");
            }
            readStream.Close();
            writeStream.Close();
            //fileInfo也可以打开文件流
            FileInfo fi = new FileInfo("test1.txt");
            FileStream read1 = fi.OpenRead();
            read1.Close();
            FileStream write1 = fi.OpenWrite();
            write1.Close();

            //3.使用StreamReader和StreamWriter，比较适合读写文本文件
            //reader和writer能自动转换编码
            StreamReader reader = new StreamReader("test1.txt");
            //while (true)
            //{
            //    int res = reader.Read();  //读取一个字符，返回ASCII码
            //    if (res == -1) break;
            //    Console.Write((char)res);
            //}
            //while (true)
            //{
            //    string str = reader.ReadLine(); //读取一行
            //    if (str == null) break;
            //    Console.Write(str);
            //}
            string str = reader.ReadToEnd();    // 读取全部
            Console.Write(str);
            reader.Close();
            StreamWriter writer = new StreamWriter("test5.txt"); //创建或覆盖一个文件
            writer.Write("a"); //写入字符或字符串
            writer.WriteLine("a");  //写入一行
            writer.Close();
            Console.ReadKey();
        }
    }
}
