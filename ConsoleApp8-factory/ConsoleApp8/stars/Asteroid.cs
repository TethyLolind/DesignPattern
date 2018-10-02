using System.Collections.Generic;

namespace SimpleFactory.stars
{
    public class Asteroid : IStars
    {
        public void AddPlanet(IStars stars)
        {
            throw new System.NotImplementedException();
        }

        public void CountainPlanet(IStars stars)
        {
            throw new System.NotImplementedException();
        }

        public List<IStars> Planets()
        {
            throw new System.NotImplementedException();
        }
    }
}