using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTry
{
    public class ClickArgs : EventArgs
    {  //第一步 写一个事件参数类 
        private readonly string v = string.Empty;
        public ClickArgs(string a)
        {
            v = a;
        }

        public string V => v;
    }

    public class SelfTry
    {
        public delegate void ClickHandler(object e, ClickArgs clickhanderargs); //第二步 写一个委托 接受一个object和一个时间参数类

        public event ClickHandler clickEvent;  //第三部 写一个生成时 会调用clickhandler委托的事件 

        public void OnClick(ClickArgs event1)  //第四部 写一个触发器，触发内容是使用事件并传入一个事件参数类
        {
            if (event1 !=null)
            {
                clickEvent(this, event1);//第八步 此时 会遍历里面存好的所有委托
            }
        }

    }


    
    public static class MethodClass
    {
        public static void haha(Object sender, ClickArgs e)  //第五步 所有被调用的方法都要接收一个ibject和一个事件参数类， 在内容中可以调用事件参数类中的参数
        {
            Console.WriteLine(e.V); 
            Console.WriteLine("haha");
        }
        public static void hehe(Object sender, ClickArgs e)
        {
            Console.WriteLine("xxxx");
        }
    }



    public class Program
    {
        static void Main(string[] args)
        {
            var x = new SelfTry();
            x.clickEvent += MethodClass.hehe; //第六步 向事件中添加委托
            x.clickEvent += MethodClass.haha;
            var eventargs = new ClickArgs("传递的信息") ;
            x.OnClick(eventargs);//第七步 触发事件
        }
    }
}
