using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp12_commond.commonder;

namespace ConsoleApp12_commond
{
    class Controller
    {

        public List<ICommonder> Commonders { get ; set ; }
        public List<ICommonder> UndoCommonders { get; set; }
        public Controller()
        {
            Commonders=new List<ICommonder>();
            UndoCommonders=new List<ICommonder>();
        }
        public void setCommonder(ICommonder commonder)
        {
            Commonders.Add(commonder);
        }

        public void Excute(string tagCommonder)
        {
            var xCommonder = this.Commonders.Aggregate((a, b) =>
            {
                if (a.tag == tagCommonder)
                {
                    return a;
                }
                return b;
            });
            xCommonder.TriggerOn();
            UndoCommonders.Add(xCommonder);
        }


        public void UndoKey()
        {
            UndoCommonders.Last().Undo();
        }
    }
}
