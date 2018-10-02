using ConsoleApp8;
using System;
using System.Collections.Generic;
using System.Text;

namespace factoryMethod
{
    public abstract class StarStore
    {
        public void ProcessStar(string type)
        {
            Star star;
            star = CreatStar(type);
            Console.WriteLine(star.Planets().Count);
            Console.WriteLine("star for sale");

        }

        protected abstract Star CreatStar(string type);

    }
}
