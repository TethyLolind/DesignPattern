using System;
using System.Collections.Generic;
using System.Text;

namespace factoryMethod
{
    class AndromedaStar:Star
    {
        public AndromedaStar(Star motherStar, int intChildStar, long selfRotatePeriod, long publicRotatePeriod)
        {
            this.motherStar = motherStar;
            this.intChildStar = intChildStar;
            this.selfRotatePeriod = selfRotatePeriod;
            this.publicRotatePeriod = publicRotatePeriod;
            NGC = "andromeda";
        }
    }
}
