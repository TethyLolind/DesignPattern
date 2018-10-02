using System.Collections.Generic;

namespace SimpleFactory.stars
{
    public interface IStars
    {
        void CountainPlanet(IStars stars);
        void AddPlanet(IStars stars);
        List<IStars> Planets();

    }
}
