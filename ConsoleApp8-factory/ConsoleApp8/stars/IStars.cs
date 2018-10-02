using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public interface IStars
    {
        void CountainPlanet(IStars stars);
        void AddPlanet(IStars stars);
        List<IStars> Planets();

    }
}
