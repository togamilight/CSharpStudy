using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019线性表 {
    class LinkList<T> : IListDS<T> {
        Node<T> head;   //链表的头结点
        int length;             //节点个数

        public LinkList(T value) {
            head  = new Node<T>(value);
            length = 1;
        }

        public LinkList() {
            head = new Node<T>();
            length = 1;
        }

        public T this[int index] {
            get {
                if(index >= 0 && index < length) {
                    Node<T> temp = head;
                    for(int i = 0; i < index; i++) {
                        temp = temp.next;
                    }
                    return temp.data;
                }
                throw new Exception("索引越界");
            }
        }

        public void Add(T item) {
            Node<T> temp = head;
            while(temp.next != null) {
                temp = temp.next;
            }
            temp.next = new Node<T>(item);
            length++;
        }

        public void Clear() {
            head = null;
            length = 0;
        }

        public T Delete(int index) {
            if (index >= 0 && index < length) {
                Node<T> temp = head;
                if (index == 0) {
                    head = head.next;
                    length--;
                    return temp.data;
                }
                for (int i = 0; i < index -1; i++) {
                    temp = temp.next;
                }
                Node<T> temp1 = temp.next;
                temp.next = temp.next.next;
                length--;
                return temp1.data;
            }
            throw new Exception("索引越界");
        }

        public T GetEle(int index) {
            if (index >= 0 && index < length) {
                Node<T> temp = head;
                for (int i = 0; i < index; i++) {
                    temp = temp.next;
                }
                return temp.data;
            }
            throw new Exception("索引越界");
        }

        public int GetLength() {
            return length;
        }

        public void Insert(T item, int index) {
            if (index >= 0 && index <= length) {
                Node<T> temp = new Node<T>(item);
                if (index == 0) {
                    temp.next = head;
                    head = temp;
                    length++;
                    return;
                }
                Node<T> preNode = head;
                for (int i = 0; i < index - 1; i++) {
                    temp = temp.next;
                }
                temp.next = preNode.next;
                preNode.next = temp;
                length++;
            }
            else throw new Exception("索引越界");
        }

        public bool IsEmpty() {
            return head == null;
        }

        public int Locate(T value) {
            Node<T> temp = head;
            for(int i = 0; temp != null; i++) {
                if (temp.data.Equals(value)) {
                    return i;
                }
                temp = temp.next;
            }
            return -1;  //找不到
        }

        public void Show() {
            Node<T> temp = head;
            while(temp != null) {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }
}
