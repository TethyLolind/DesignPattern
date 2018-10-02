namespace FactoryMethod.Star.andromedastar
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
