using System;

namespace FactoryMethod.Star.galaystar
{
    class GalaxyStar_asteroid : Star
    {
        public GalaxyStar_asteroid()
        {

        }
        public GalaxyStar_asteroid(Star motherStar,int intChildStar,long selfRotatePeriod,long publicRotatePeriod)
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
