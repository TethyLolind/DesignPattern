using System.Collections.Generic;

namespace ConsoleApp9_observer
{
    internal class Subject1
    {
        private int _parameter1;
        private int _parameter2;
        public List<IObserber1> OberserList;

        public Subject1()
        {
            OberserList = new List<IObserber1>();
        }

        public void setParameter1(int para1, int para2)
        {
            _parameter1 = para1;
            _parameter2 = para2;
            Parameterchanged();
        }

        private void Parameterchanged()
        {
            notifyObserver();
        }

        public void notifyObserver()
        {
            foreach (var obserber in OberserList) obserber.update(_parameter1, _parameter2);
        }

        public void register(Obserber1 obserber1)
        {
            OberserList.Add(obserber1);
        }

        public void remove(Obserber1 obserber1)
        {
            var index = OberserList.IndexOf(obserber1);
            if (index > 0) OberserList.Remove(obserber1);
        }
    }
}