using System;

namespace ConsoleApp9_observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Subject1();
            var b1= new Obserber1(a);
            var b2=  new Obserber1(a);
            var b3 = new Obserber1(a);
            var b4 = new Obserber1(a);
            var b5 = new Obserber1(a);

            b3.Flag = false;

            b1.Tag = "x";
            b2.Tag = "xx";
            b3.Tag = "xxx";
            b4.Tag = "xxxx";
            b5.Tag = "xxxxx";
               

            b1.register();
            b2.register();
            b5.register();
            b3.register();
            b4.register();
           //按注册顺序增加 并遍历发送

            a.setParameter1(1,2);
        }
    }
}
