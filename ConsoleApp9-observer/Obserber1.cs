using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9_observer
{
  

    class Obserber1 : IObserber1
    {
        private Subject1 subject1;
        private string tag;
        private bool flag=true;

        public string Tag { get => tag; set => tag = value; }
        public bool Flag { get => flag; set => flag = value; }

        public Obserber1(Subject1 subject1)
        {
            this.subject1 = subject1;
        }

        public void update(int parameter1, int parameter2)
        {
            if (Flag)
            {
                Console.WriteLine(parameter1.ToString() + parameter2.ToString() + "+++++++++++" + this.GetType().Name + Tag);
            }
            
        }

        public void register()
        {
            subject1.register(this);
        }

        public void remove()
        {
            subject1.remove(this);
        }

    }
}
