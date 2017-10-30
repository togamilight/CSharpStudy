using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件的完整声明 {
    class Program {
        static void Main(string[] args) {
            Caller caller = new Caller("caller");
            BeCalleder beCalleder = new BeCalleder("beCalleder");
            caller.Call += beCalleder.BeCalled;
            caller.OnCall();

            Console.ReadKey();
        }
    }

    delegate void CallEventHandler(Caller caller, CallEventArgs e);

    //事件参数类
    class CallEventArgs : EventArgs {
        public string message;
        public CallEventArgs(string m) : base() {
            message = m;
        }
        public CallEventArgs() : base() {
            message = "default message";
        }
    }

    //被呼叫者，事件的订阅者
    class BeCalleder {
        string name;
        public BeCalleder(string n) {
            name = n;
        }

        //事件调用的方法，参数列表一般为(object sender, EventArgs e)
        public void BeCalled(Caller caller, CallEventArgs e) {
            Console.WriteLine("{0}: {1} call me, say:\"{2}\"", name, caller.name, e.message);
        }
    }

    //呼叫者
    class Caller {
        public string name;
        public Caller(string n) {
            name = n;
        }

        //事件的完整声明Start-----------
        //此时，该事件只能+=/-=
        private CallEventHandler callEventHandler;
        public event CallEventHandler Call {
            add {
                callEventHandler += value;
            }
            remove {
                callEventHandler -= value;
            }
        }
        //事件的完整声明End------------

        //事件的简略声明,此时该事件在类外可+=/-=，类内可Invoke/=
        //public event CallEventHandler call;

        
        public void OnCall() {
            if(callEventHandler != null) {
                CallEventArgs e = new CallEventArgs("Hello");
                callEventHandler(this, e);
            }
        }
    }
}
