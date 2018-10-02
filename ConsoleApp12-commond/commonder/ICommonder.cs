using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12_commond
{
    public interface ICommonder
    {
        string tag { get; set; }
        void SetItem(IActioner actioner);
        void TriggerOn();

        void Undo();
    }
}
