using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008LINQ
{
    //武林高手类
    class MartialArtsMaster
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String Menpai { get; set; }
        public String Kungfu { get; set; }
        public int Level { get; set; }
        public override string ToString()
        {
            return "Id:" + Id + " Name:" + Name + " Age:" + Age + " Menpai:" + Menpai + " Kungfu:" + Kungfu + " Level:" + Level;
        }
    }
}
