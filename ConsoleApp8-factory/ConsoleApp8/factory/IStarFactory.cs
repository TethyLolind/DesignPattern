using System;

namespace ConsoleApp8
{
    public interface IStarFactoy
    {
        void CreatStarSun();
        IStars CreatStarPlanet(string starType);
        void AttackStar();

    }

}
