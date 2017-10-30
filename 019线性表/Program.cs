using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019线性表 {
    class Program {
        static void Main(string[] args) {
            LinkList<string> strs = new LinkList<string>("a");
            strs.Add("b");
            strs.Add("c");
            strs.Show();
            strs.Insert("0", 0);
            strs.Insert("1", 1);
            strs.Show();
            Console.WriteLine(strs.GetLength());
            strs.Delete(3);
            strs.Show();

            SeqList<string> seqList = new SeqList<string>();
            seqList.Add("a");
            seqList.Add("b");
            seqList.Add("c");
            seqList.Show();
            


            Console.ReadKey();
        }
    }
}
