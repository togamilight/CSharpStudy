using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003实现自己的集合类MyList
{
    class MyList<T>
    {
        private T[] array;
        private int count = 0;  //当前元素个数

        public MyList(int size)
        {
            if (size < 0) size = 0;
            array = new T[size];
        }

        public MyList() : this(0){ }

        public int Capacity     //数组长度
        {
            get { return array.Length; }

            set
            {
                if (value == array.Length) ;
                else if (value >= Count)
                {
                    T[] newArray = new T[value];
                    Array.Copy(array, newArray, Count);
                    array = newArray;
                }
                else throw new Exception("设置容量不够！");
            }
        }

        public int Count
        {
            get { return count; }
        }

        //扩容数组
        private void Expand()
        {
            if (Count == Capacity)   //当数组容量不够用时扩容数组
            {
                if (Capacity == 0)   //当数组容量为0时创建容量为4的数组
                    array = new T[4];
                else
                {
                    T[] newArray = new T[Capacity * 2]; //创建两倍于原来容量的新数组
                    Array.Copy(array, newArray, Count);  //复制原来的数组到新数组
                    array = newArray;
                }
            }
        }

        //添加元素
        public void Add(T item)
        {
            Expand();
            array[Count] = item;    //往数组中加入新元素
            count++;    //元素数量自增
        }

        public T this[int index]    //索引器
        {
            get
            {
                if (index >= 0 && index < Count)
                    return array[index];
                else throw new Exception("索引越界！"); 
            }

            set
            {
                if (index >= 0 && index < Count)
                    array[index] = value;
                else throw new Exception("索引越界！");
            }
        }

        //插入元素
        public void Insert(int index, T item)
        {
            if(index >= 0 && index < Count)
            {
                Expand();
                for(int i = Count - 1; i >= index; i--)
                    array[i + 1] = array[i];    //将index及其后元素都向后移一位
                array[index] = item;
                count++;
            }
            else throw new Exception("索引越界！");
        }

        //移除元素
        public void RemoveAt(int index)
        {
            if(index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; i++)
                    array[i] = array[i + 1];    //将index及其后元素都向前移一位
                count--;
            }
            else throw new Exception("索引越界！");
        }

        //获取第一个item位置
        public int IndexOf(T item)
        {
            for(int i = 0; i < Count; i++)
            {
                if (array[i].Equals(item))
                    return i;
            }
            return -1;
        }

        //获取最后一个item位置
        public int LastIndexOf(T item)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (array[i].Equals(item))
                    return i;
            }
            return -1;
        }
    }
}
