using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    class StarStore
    {
        private IStarFactoy starsFactory;
        public StarStore(IStarFactoy starsFactory)
        {
            this.starsFactory = starsFactory;
        }
        public IStars generateStar(string type) 
        {
            var star1 = starsFactory.CreatStarPlanet(type);
            //var star2 = starsFactory.CreatStarPlanet("asteroid");
            //star1.AddPlanet(star2);
            //Console.WriteLine(star1.Planets().Count); 
            return star1;
            
        }
    }
}
