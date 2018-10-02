using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class Planet : IStars
    {
        private IStars motherStar;
        private int numberOfPlant;
        private long selfRotatePeriod;
        private long publicRotatePeriod;
        private List<IStars> planets= new List<IStars>();
        private string typeOfPlanet;

        public Planet()
        {
        }

        public Planet(IStars motherStar, int numberOfPlant, long selfRotatePeriod, long publicRotatePeriod)
        {
            this.motherStar = motherStar;
            this.numberOfPlant = numberOfPlant;
            this.selfRotatePeriod = selfRotatePeriod;
            this.publicRotatePeriod = publicRotatePeriod;

        }

      
        public void AddPlanet(IStars star)
        {
            planets.Add(star);
        }

        public void CountainPlanet(IStars stars)
        {
            if (stars!=null)
            {

            }
            throw new Exception();

        }

        public List<IStars> Planets()
        {
            return planets;
        }
    }
}
