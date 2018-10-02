using System;
using System.Collections.Generic;
using System.Text;

namespace factoryMethod
{
    public class Star//抽象工厂的话 就是把银河和仙女作为两个星子类  然后
    {
        protected string NGC;
        protected Star motherStar;
        protected int intChildStar;
        protected long selfRotatePeriod;
        protected long publicRotatePeriod;
        protected string typeOfPlanet;//变量留在超类里面 在子类里面得构造函数中填好

        protected List<Star> childStars = new List<Star>();

        protected void AddPlanet(Star childStar)
        {
            childStars.Add(childStar);
        }

        public void CountainPlanet(Star stars)
        {
            if (stars != null)
            {

            }
            throw new Exception();

        }

        public List<Star> Planets()
        {
            return childStars;
        }

        protected virtual void CustomMethod()
        {
        }
    }
}
