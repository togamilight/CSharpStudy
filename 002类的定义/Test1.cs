using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002类的定义 {
    class Test1 {
        private Test test;
        public Test Test {
            get {
                return test;
            }
            set {
                if (value.GetType().Equals(typeof(Test))){
                    test = value;
                }
            }
        }
        
    }
}
