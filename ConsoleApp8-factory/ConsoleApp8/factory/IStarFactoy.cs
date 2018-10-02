using SimpleFactory.stars;

namespace SimpleFactory.factory
{
    public interface IStarFactoy
    {
        void CreatStarSun();
        IStars CreatStarPlanet(string starType);
        void AttackStar();

    }

}
