using System;
using System.Collections.Generic;
using System.Text;
using SimpleFactory;
using SimpleFactory.factory;
using SimpleFactory.stars;

namespace ConsoleApp8
{
    internal class GlaxyStarStore : StarStore
    {
        public GlaxyStarStore(IStarFactoy starsFactory) : base(starsFactory)
        {
        }

        public override IStars CreateStar(string type)
        {
            throw new NotImplementedException();
        }
    }
}
