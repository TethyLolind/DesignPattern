using System;
using System.Collections.Generic;
using System.Text;

namespace factoryMethod
{
    class GalaxyStar_planet : Star
    {
        public GalaxyStar_planet()
        {

        }
        public GalaxyStar_planet(Star motherStar,int intChildStar,long selfRotatePeriod,long publicRotatePeriod)
        {
            this.motherStar = motherStar;
            this.intChildStar = intChildStar;
            this.selfRotatePeriod = selfRotatePeriod;
            this.publicRotatePeriod = publicRotatePeriod;
            NGC = "galaxy";
        }

        protected override void CustomMethod()
        {
            Console.WriteLine("mother NGC");
        }




    }
}
