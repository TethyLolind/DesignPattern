using System;

namespace FactoryMethod.Store
{
    public abstract class StarStore
    {
        public void ProcessStar(string type)
        {
            Star.Star star;
            star = CreatStar(type);
            Console.WriteLine(star.Planets().Count);
            Console.WriteLine("star for sale");

        }

        protected abstract Star.Star CreatStar(string type);

    }
}
