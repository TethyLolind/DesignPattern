using System.Collections.Generic;

namespace ConsoleApp9_observer
{
    internal class Subject1
    {
        private int parameter1;
        private int parameter2;
        public  List<IObserber1> oberserList;

        public Subject1()
        {
            this.oberserList=new List<IObserber1>();
        }
        public void setParameter1(int para1, int para2)
        {
            this.parameter1 = para1;
            this.parameter2 = para2;
            parameterchanged();
        }

        private void parameterchanged()
        {
            notifyObserver();
        }

        public void notifyObserver()
        {
            foreach (var obserber in oberserList)
            {
                obserber.update(this.parameter1, this.parameter2);
            }
        }
      

        public void register(Obserber1 obserber1)
        {
            this.oberserList.Add(obserber1);
            
        }

        public void remove(Obserber1 obserber1)
        {
            var index=oberserList.IndexOf(obserber1);
            if (index>0)
            {
                oberserList.Remove(obserber1);
            }
        }

    }
}