using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008LINQ
{
    //武学类
    class Kungfu
    {
        public int KungfuId { get; set; }
        public String KungfuName { get; set; }
        public int Power { get; set; }
        public override string ToString()
        {
            return "KungfuId:"+KungfuId+" KungfuName:"+KungfuName+" Power:"+Power;
        }
    }
}
