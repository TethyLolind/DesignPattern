﻿using System;

namespace ConsoleApp10_decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var a =new Coast();
            
            var b= new Milk();

            var c=new Mocha();

            a.Price = 9;
            b.Price = 10;
            c.Price = 99;

            a.Description = "coast";
            b.Description = "milk";
            c.Description = "mocha";

            a.X = b;
            c.X = a;

            Console.WriteLine(a.GetName()+" price:");
            Console.WriteLine(a.cost());
            Console.WriteLine(c.GetName() + " price:");
            Console.WriteLine(c.cost());

        }
    }
}
