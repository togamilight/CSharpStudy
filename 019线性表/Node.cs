using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 单链表的节点类
/// </summary>
namespace _019线性表 {
    class Node<T> {
        public T data;     //数据
        public Node<T> next;   //指向下一个结点
        public Node() {
            data = default(T);      //default关键字表示该类型的默认值
            next = null;
        }
        public Node(T data) {
            this.data = data;
            next = null;
        }
        public Node(T data, Node<T> next) {
            this.data = data;
            this.next = next;
        }
    }
}
