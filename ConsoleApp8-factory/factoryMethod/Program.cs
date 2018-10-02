using System;

namespace factoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new galaxyStore();
            store.ProcessStar("planet");
           

        }
    }
}
