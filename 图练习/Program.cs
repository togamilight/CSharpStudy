using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图练习 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("请输入所有顶点数据（以空格分隔）:");
            string[] strs = (Console.ReadLine()).Split(' ');    //接收输入的顶点数据
            Graph graph = new Graph(strs);
            Console.WriteLine("您输入的所有顶点如下：");
            for(int i = 0; i < strs.Length; i++) {
                Console.WriteLine("{0}:{1}", i, strs[i]);
            }

            Console.WriteLine("请输入所有边关系（起始点 结束点, 输入0结束）：");
            do {
                string[] str12 = (Console.ReadLine()).Split(' ');
                if(str12.Length == 2) {
                    int flag = graph.AddEge(str12[0], str12[1]);
                    switch (flag) {
                        case -2:
                            Console.WriteLine("两点相同，请重新输入：");
                            break;
                        case -1:
                            Console.WriteLine("两数据不存在，请重新输入：");
                            break;
                        case 0:
                            Console.WriteLine("边已存在，请重新输入：");
                            break;
                        case 1:
                            break;
                    }
                }
                else if (str12.Length == 1 && str12[0] == "0")
                    break;
                else {
                    Console.WriteLine("一次输入两个点({0})，请重新输入：", str12.Length);
                }
            } while (true);

            graph.Show();

            graph.DFS();

            graph.BFS();
            Console.ReadKey();
        }
    }
}
