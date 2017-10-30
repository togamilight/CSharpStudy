using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007观察者设计模式_猫抓老鼠_事件的应用
{
    //观察者类
    class Mouse
    {
        public String Name { get; private set; }
        public Mouse(String name, Cat cat)
        {
            Name = name;
            //在事件中注册行为
            cat.CatComeEvent += RunAway;
        }

        public void RunAway()
        {
            Console.WriteLine("小老鼠" + Name + "看到了猫，飞快地跑了出去");
        }
    }
}
