using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002类的定义
{
    enum mySex
    {
        male,
        female
    }

    class Character
    {
        //习惯上将字段定义为private，并给出首字母大写的同名属性来控制get/set方法
        //private string name;
        //private mySex sex;
        private int age;

        //默认形式,可以不定义name,即使有name,值也不会传过去
        public string Name { set; get; }
        public mySex Sex { set; get; }

        //主要作用，预处理数据
        public int Age
        {
            set
            {
                if (value >= 0)
                    age = value;
                else age = 0;
            }
            get { return age; }
            //get;//不能单独用默认形式
        }


        //没有构造函数时，系统提供默认无参构造函数
        //有构造函数时，则最好自己定义一个无参构造函数
        public Character() : this("赵日天", mySex.male, 18)//构造函数调用另一个重载的构造函数
        {
        }

        public Character(string name, mySex sex, int age)
        {
            Name = name;
            Sex = sex;
            Age = age;
            Console.WriteLine("新建了一个角色");
        }

        public virtual void show()
        {
            Console.WriteLine("角色信息：");
            Console.WriteLine("姓名：{0}，性别：{1}，年龄：{2}", Name, Sex, Age);
        }
    }
}
