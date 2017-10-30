using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型练习 {
    /// <summary>
    /// 泛型枚举类，从0枚举到9，CodeList3-10
    /// 可枚举类可以用foreach遍历
    /// </summary>
    class CountingEnumerable : IEnumerable<int> {
        //隐式实现IEnumerator<int>
        public IEnumerator<int> GetEnumerator() {
            return new CountingEnumerator();
        }

        //显式实现IEnumerable
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();   
        }
    }

    class CountingEnumerator : IEnumerator<int> {
        int current = -1;
        //隐式实现IEnumerator<int>
        public int Current {
            get {
                return current;
            }
        }

        //显式实现IEnumerator
        object IEnumerator.Current {
            get {
                return Current;
            }
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public bool MoveNext() {
            ++current;
            return current < 10;
        }

        public void Reset() {
            current = -1;
        }
    }
}
