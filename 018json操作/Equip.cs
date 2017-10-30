using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018json操作
{
    class Equip
    {
        public int id;
        public string name;
        public string iconName;
        public int price;
        public int starLevel;
        public int quality;
        public int damage;
        public string des;
        public override string ToString()
        {
            return "id:" + id + " name:" + name + " iconName:" + iconName + " price:" + price + " starLevel:" + starLevel + " quality:" + quality + " damage:" + damage + " des:" + des;
        }
    }
}
