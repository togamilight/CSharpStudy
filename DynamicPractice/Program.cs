using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicPractice {
    static class Program {
        static void Main(string[] args) {
            //IntAddInt();

            //AddConditionallyTest();

            //DynamicSumTest();

            CountTest();

            Console.ReadKey();
        }

        #region CodeList 14-3
        static void IntAddInt() {
            dynamic items = new List<int> { 1, 2, 3 };
            dynamic addValue = 2;
            foreach(dynamic item in items) {
                //string result = item + addValue;  //异常，无法将 int 隐式转换为 string
                Console.WriteLine(item + addValue);
            }
        }
        #endregion

        #region CodeList 14-11 执行时类型推断
        private static bool AddConditionallyImpl<T>(IList<T> list, T item) {
            if(list.Count < 10) {
                list.Add(item);
                return true;
            }
            return false;
        }

        public static bool AddConditionally(dynamic list, dynamic item) {
            return AddConditionallyImpl(list, item);
        }

        public static void AddConditionallyTest() {
            var nums = new List<int> { 1, 2, 3 };
            AddConditionally(nums.Count, 4);
            nums.ForEach(x => Console.WriteLine(x));
        }
        #endregion

        #region CodeList 14-12 动态对任意元素序列求和
        static T DynamicSum<T>(this IEnumerable<T> source) {
            dynamic total = default(T);
            foreach(T element in source) {
                //total = (T)(total + element);
                total += element;
            }

            return (T)total;
        }

        static void DynamicSumTest() {
            byte[] bytes = new byte[] { 1, 2, 3 };
            Console.WriteLine(bytes.DynamicSum());
        }
        #endregion

        #region CodeList 14-15 多重分发
        static int CountImpl<T>(ICollection<T> c) {
            return c.Count;
        }
        static int CountImpl(ICollection c) {
            return c.Count;
        }
        static int CountImpl(string s) {
            return s.Length;
        }
        static int CountImpl(IEnumerable e) {
            int count = 0;
            foreach(var item in e) {
                count++;
            }
            return count;
        }
        static void PrintCount(IEnumerable c) {
            dynamic d = c;
            Console.WriteLine(CountImpl(c));
        }
        static void CountTest() {
            PrintCount(new BitArray(5));
            PrintCount(new HashSet<int> { 1, 2});
            PrintCount("ABC");
            PrintCount("ABCDE".Where(x => x > 'B'));
        }
        #endregion
    }
}
