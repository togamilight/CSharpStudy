using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010特性
{
    //自定义特性类
    //命名最后要加Attribute，继承自System.Attribute
    //一般情况下声明为sealed（不能被继承）
    //特性类用来表示目标结构的一些状态（一般不定义方法，只有字段或属性）
    [AttributeUsage(AttributeTargets.Class)]    //指出特性类的作用目标
    sealed class MyTestAttribute : System.Attribute
    {
        public string Description { get; set; }
        public string Version { get; set; }
        public MyTestAttribute(string desc)
        {
            this.Description = desc;
        }
    }
}
