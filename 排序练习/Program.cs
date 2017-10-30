using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序练习
{
    class Program
    {
        //基本冒泡排序
        static void BubbleSort(int[] a)
        {
            int temp = 0;
            for(int i = 0; i < a.Length - 1; i++)
            {
                for(int j = 0; j < a.Length - i - 1; j++)
                {
                    if(a[j] > a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
                //foreach (int b in a)
                //    Console.Write(b + " ");
                //Console.WriteLine();
            }
        }

        //快速排序
        static void HurrySort(int[] a, int start, int end) {
            if (start >= end) return;
            int i = start;
            int j = end;
            int temp = a[i];
            while (j > i) {
                for (; j > i; j--) {
                    if (a[j] <= temp) {
                        a[i++] = a[j];
                        break;
                    }
                }
                for (; i < j; i++) {
                    if (a[i] > temp) {
                        a[j--] = a[i];
                        break;
                    }
                }
            }
            a[i] = temp;
            HurrySort(a, start, i - 1);
            HurrySort(a, i + 1, end);
        }

        //选择排序
        static void SelectSort(int[] a)
        {
           int tag = 0;
           for (int i = 0; i < a.Length - 1; i++) {
                tag = i;
                for(int j = i + 1; j < a.Length; j++) {
                    if(a[tag] > a[j]) {
                        tag = j;
                    }
                }
                int temp = a[i];
                a[i] = a[tag];
                a[tag] = temp;
            }
        }

        static void Main(string[] args)
        {
            int[] a = { 9,8,7,6,5,4,3,2,1,0 };
            foreach (int i in a)
                Console.Write(i + " ");
            Console.WriteLine();
            //BubbleSort(a);
            //HurrySort(a, 0, a.Length-1);
            SelectSort(a);
            foreach (int i in a)
                Console.Write(i + " ");
            Console.ReadKey();
        }
    }
    
}
