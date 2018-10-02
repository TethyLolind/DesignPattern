using System;
using System.Collections.Generic;
using SimpleFactory.stars;

namespace SimpleFactory.factory
{
     class GalaxyStarFactory:IStarFactoy
    {
    
        public void AttackStar()
        {
            throw new NotImplementedException();
        }

        public IStars  CreatStarPlanet(String starType)
        {
            List<string> StarType = new List<string> { "galaxy_planet", "galaxy_stella", "galaxy_asteroid" };
            IStars star;
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
                    case "galaxy_planet":
                        star = new Planet();
                        return star;
                    case "galaxy_stella":
                        star = new Stella();
                        return star;
                    case "galaxy_asteroid":
                        star = new Asteroid();
                        return star;
                }
            }
            return null;
        }

        public void CreatStarSun()
        {
            throw new NotImplementedException();
        }

    
    }
}
