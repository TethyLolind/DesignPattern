using System;
using System.Collections.Generic;
using FactoryMethod.Star.galaystar;

namespace FactoryMethod.Store
{
    class galaxyStore : StarStore
    {
        protected override Star.Star CreatStar(string starType)
        {
            Star.Star returnStar;
            List<string> StarType = new List<string> { "planet", "stella", "asteroid" };
            starType = starType.ToLower();
            if (!StarType.Contains(starType))
            {
                Console.WriteLine("wrong star!");
                throw new Exception();
            }
            else
            {
                switch (starType)
                {
                    case "planet":
                        returnStar = new GalaxyStar_planet();//可以再给这些具体的星类中传入一个参数工厂（接口）代替复杂的参数，用参数工厂给行星赴参数
                        return returnStar;
                    case "stella":
                        returnStar = new GalaxyStar_stella();
                        return returnStar;
                    case "asteroid":
                        returnStar = new GalaxyStar_asteroid();
                        return returnStar;
                }
            }
            return null;
        }
    }
}
