namespace ConsoleApp10_decorator
{
    class Mocha:IMaterials
    {
        public long Price { get; set; }
        public IMaterials X { get; set; }
        public long cost()
        {
            if (X == null)
            {
                return Price;
            }
            return Price + X.cost();
        }

        public string Description { get; set; }
        public string GetName()
        {
            if (X == null)
            {
                return Description;
            }
            return Description + X.GetName();
        }
    }
}