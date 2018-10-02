using System;
using System.Linq;

namespace ConsoleApp12_commond
{
    class Program
    {
        static void Main(string[] args)
        {
             var remoteController = new Controller();
            var lightCommonder=new LightCommonderOn();
            var light=new BedroomLight();
            lightCommonder.SetItem(light);

            remoteController.setCommonder(lightCommonder);

            remoteController.Excute("bedroomlight");

            remoteController.UndoKey();
        }
    }
}
