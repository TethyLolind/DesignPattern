using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTry
{
    class EventTry2
    {
        public event EventHandler TryEvent;
        //eventhandler这个委托是系统默认的 是一个 接受一对object sender 和 eventargs  返回void的委托
        public void Register()
        {
            TryEvent += MethodCollection.Method1;
            TryEvent +=new EventHandler(MethodCollection.Method2);//直接new一个委托 把方法用构造注入进去
        }

        public void run()
        {
            if (TryEvent != null) TryEvent(this, new EventArgs());
        }



        public event EventHandler<newArgs> TryEvent2;

        public void register2()
        {
            TryEvent2 += MethodCollection.Method4;
        }
        public void run2()
        {
            //if (TryEvent2 != null) TryEvent2(this, new newArgs("spicy"));  下面那句和这句等价的 ？是用来判断非空
            TryEvent2?.Invoke(this, new newArgs("spicy"));
        }


    }

    

    public class MethodCollection
    {
        public static void Method1(object sender,EventArgs args)
        {
            Console.WriteLine("cool");
        }

        public static void Method2(object sender, EventArgs args)
        {
            Console.WriteLine("cold");
        }
        public static void Method3(object sender, EventArgs args)
        {
            Console.WriteLine("frozen");
        }




        public static void Method4(object sender, newArgs e)
        {
           
            Console.WriteLine(e.Para);
        }
    }
 public  class newArgs : EventArgs
    {
        public newArgs(string arg)
        {
            Para = arg;
        }
        public String Para { get; }
    }


}
