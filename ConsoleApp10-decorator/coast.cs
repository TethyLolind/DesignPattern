namespace ConsoleApp10_decorator
{
    class Coast : IMaterials
    {
        public IMaterials X { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }
        public long cost()
        {
            if (X==null)
            {
                return Price;
            }
            return Price + X.cost(); 
        }

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