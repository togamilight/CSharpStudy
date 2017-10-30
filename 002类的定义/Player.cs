using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002类的定义
{
    class Player : Character
    {
        public Player() : base()
        {
            this.Age = 1;
        }
        public override void show()
        {
            Console.WriteLine("I am a player");
        }
    }
}
