using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图练习 {
    /// <summary>
    /// 邻接表式图
    /// </summary>
    class Graph {
        public VNode[] vnodes;  //顶点列表
        //检索顶点
        public VNode this[int index] {
            get {
                return vnodes[index];
            }
        }

        public Graph(string[] strs) {
            vnodes = new VNode[strs.Length];
            for(int i = 0; i < vnodes.Length; i++) {
                vnodes[i] = new VNode(strs[i]);
            }
        }

        /// <summary>
        /// 为两个节点间增加边
        /// </summary>
        /// <param name="data1">起始节点数据</param>
        /// <param name="data2">到达节点数据</param>
        /// <returns>添加是否成功, -2： 两数据相同  -1：两数据不存在，0：边已存在，1：成功</returns>
        public int AddEge(string data1, string data2) {
            if (data1 == data2)     //两数据相同
                return -2;

            VNode vn1 = null;
            VNode vn2 = null;
            foreach(var vn in vnodes) {
                if (vn.Data == data1)
                    vn1 = vn;
                else if (vn.Data == data2)
                    vn2 = vn;
            }
            if (vn1 == null || vn2 == null)  //两数据不存在与顶点列表中
                return -1;

            ANode node = vn1.firstNode;
            while(node != null) {   //判断边是否存在
                if (node.vnode == vn2)
                    return 0;
                node = node.next;
            }

            //插入vn1所在链表的头部
            node = new ANode(vn2, vn1.firstNode);
            vn1.firstNode = node;
            return 1;
        }

        /// <summary>
        /// 打印该邻接表
        /// </summary>
        public void Show() {
            foreach(var vn in vnodes) {
                Console.Write(vn.Data + "-->");
                ANode node = vn.firstNode;
                while(node != null) {
                    Console.Write(" " + node.vnode.Data);
                    node = node.next;
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        ///从第一个顶点开始深度优先遍历
        /// </summary>
        public void DFS() {
            for(int i = 0; i < vnodes.Length; i++) {    //重置是否被访问为否
                vnodes[i].isVisited = false;
            }
            Console.Write("深度优先遍历");
            foreach(var vn in vnodes) {             //对所有未访问顶点进行深度优先遍历
                    DFSVnode(vn);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 对顶点进行深度优先遍历
        /// </summary>
        /// <param name="vn"></param>
        void DFSVnode(VNode vn) {
            if (vn.isVisited) return;
            vn.isVisited = true;

            Console.Write(" " + vn.Data);

            ANode anode = vn.firstNode;
            while(anode != null) {
                DFSVnode(anode.vnode);
                anode = anode.next;
            }
        }

        public void BFS() {
            Console.Write("广度优先遍历:");

            for (int i = 0; i < vnodes.Length; i++) {    //重置是否被访问为否
                vnodes[i].isVisited = false;
            }

            foreach (var vn in vnodes) {
                if (vn.isVisited) continue;
                Queue<VNode> vNodeQue = new Queue<VNode>(); //队列
                Console.Write(" " + vn.Data);
                vn.isVisited = true;
                vNodeQue.Enqueue(vn);
                while(vNodeQue.Count != 0) {
                    VNode vnode = vNodeQue.Dequeue();   //出队
                    ANode anode = vnode.firstNode;
                    while(anode != null) {
                        vnode = anode.vnode;
                        if(vnode.isVisited == false) {
                            Console.Write(" " + vnode.Data);
                            vnode.isVisited = true;
                            vNodeQue.Enqueue(vnode);
                        }
                        anode = anode.next;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 顶点类
    /// </summary>
    class VNode {
        public string Data { get; set; }    //存放的信息
        public ANode firstNode;             //邻接的第一个节点
        public bool isVisited;                  //是否被访问过，用于遍历时 
        public VNode(string data) {
            Data = data;
            firstNode = null;
            isVisited = false;
        }
    }

    /// <summary>
    /// 结点类
    /// </summary>
    class ANode {
        public readonly VNode vnode;    //对应的顶点
        public ANode next;                      //下一个节点
        public ANode(VNode vn, ANode nextNode) {
            vnode = vn;
            next = nextNode;
        }
    }
}
