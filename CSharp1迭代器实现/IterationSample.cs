using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp1迭代器实现 {
    class IterationSample : IEnumerable {
        object[] values;
        int startingPoint;  //起点

        public IterationSample(object[] vs, int sp) {
            this.values = vs;
            this.startingPoint = sp;
        }
        public IEnumerator GetEnumerator() {
            return new IterationSampleIterator(this);
        }

        class IterationSampleIterator : IEnumerator {
            IterationSample parent;     //正在迭代的集合
            int position;       //当前遍历到的位置

            internal IterationSampleIterator(IterationSample parent) {
                this.parent = parent;
                position = -1;      //在第一个元素之前开始
            }

            public object Current {
                get {
                    if(position == -1 || position == parent.values.Length) {    //防止越界
                        throw new InvalidOperationException();
                    }
                    int index = position + parent.startingPoint;
                    index = index % parent.values.Length;
                    return parent.values[index];
                }
            }

            public bool MoveNext() {
                if(position != parent.values.Length) {
                    position++;
                }
                return position < parent.values.Length;
            }

            public void Reset() {
                position = -1;
            }
        }
    }
}
