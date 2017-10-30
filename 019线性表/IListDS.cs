using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019线性表 {
    /// <summary>
    /// 线性表接口
    /// </summary>
    interface IListDS <T> {
        int GetLength();
        void Clear();
        bool IsEmpty();
        void Add(T item);
        void Insert(T item, int index);
        T Delete(int index);
        T this[int index] { get; }
        T GetEle(int index);
        int Locate(T value);
        void Show(); 
    }
}
