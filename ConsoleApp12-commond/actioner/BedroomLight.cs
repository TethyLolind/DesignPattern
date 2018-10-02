using System;

namespace ConsoleApp12_commond
{
    internal class BedroomLight:IActioner
    {
        public void OnAction()
        {
            Console.WriteLine("light turened on");
        }

        public void OffAction()
        {
            Console.WriteLine("light turened off");
        }
    }
}