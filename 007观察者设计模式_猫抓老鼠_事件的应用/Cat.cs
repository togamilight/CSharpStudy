using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007观察者设计模式_猫抓老鼠_事件的应用
{
    //被观察者类
    class Cat
    {
        public String Name { get; private set; }
        //定义事件，事件只能在类中被触发
        public event Action CatComeEvent;

        public Cat(String name)
        {
            Name = name;
        }

        public void CatComing()
        {
            Console.WriteLine("大猫" + Name + "冲进来了!");
            //当事件不为空(已注册有行为)时,触发事件
            if(CatComeEvent != null)
                CatComeEvent();
        }
    }
}
