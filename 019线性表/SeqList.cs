using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019线性表 {
    /// <summary>
    /// 顺序表实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SeqList<T> : IListDS<T> {

        private T[] data;   //数据数组
        private int count;  //数据个数

        public SeqList(int size) {  //size:开辟的数组长度
            if (size < 1) size = 1;
            data = new T[size];
        }

        public SeqList() : this(4) {

        }

        public T this[int index] {
            get {
                if (index >= 0 && index < count) {
                    return data[index];
                }
                else throw new Exception("索引越界");
            }
        }

        public void Add(T item) {
            Expand();
            data[count++] = item;
        }

        public void Clear(){
            data = new T[1];
            count = 0;
        }

        public T Delete(int index) {
            if (index >= 0 && index < count) {
                T temp = data[index];
                for (int i = index; i < count; i++) {   //前移一位
                    data[i] = data[i + 1];
                }
                return temp;
            }
            else throw new Exception("索引越界");
        }

        public T GetEle(int index) {
            if (index >= 0 && index < count) {
                return data[index];
            }
            else throw new Exception("索引越界");
        }

        public int GetLength() {
            return count;
        }

        public void Insert(T item, int index) {
            Expand();
            if (index >= 0 && index <= count) {
                for(int i = count -1; i >= index; i--) {       //后移一位
                    data[i + 1] = data[i];
                }
                data[index] = item;
            }
            else throw new Exception("索引越界");
        }

        public bool IsEmpty() {
            return count == 0;
        }

        public int Locate(T value) {
            for(int i= 0; i < count; i++) {
                if (data[i].Equals(value)) return i;
            }
            return -1;
        }

        public void Show() {
            for(int i= 0; i < count; i++) {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }

        private void Expand() { //数组满时扩容数组
            if(count == data.Length) {
                T[] temp = new T[count * 2];    //扩容为两倍
                Array.Copy(data, temp, count);
                data = temp;
            }
        }
    }
}
