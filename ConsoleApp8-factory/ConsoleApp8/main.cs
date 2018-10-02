using System;
using SimpleFactory.factory;

namespace SimpleFactory
{
    class main
    {
        static void Main()
        {
            var starFactory = new GalaxyStarFactory();//相当于选择哪一种工厂
            var a = new StarStore(starFactory);//可以接受任意工厂的产品
            var star=a.generateStar("galaxy_planet");
            Console.WriteLine(star.Planets().Count); 
        }
    }
}
