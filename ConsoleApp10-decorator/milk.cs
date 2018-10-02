using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp10_decorator
{


    class milk: IMaterials
    {
        public IMaterials X { get; set; }
        public long Price { get; set ; }
        public string Description { get; set; }

        public long cost()
        {
            if (X == null)
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

    class coast : IMaterials
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

    class mocha:IMaterials
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
