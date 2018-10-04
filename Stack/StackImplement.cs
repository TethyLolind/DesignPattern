using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Stack
{
    class StackImplement : Stack<String>
    {

    }

    class DoubleLinkNodeImplement : LinkedList<string>
    {

    }


    class QueueImplement : Queue<string>
    {

    }



    
    class Program
    {

        static void Main()
        {
            var stack1=new StackImplement();

            var count = 0;
            while (count<100)
            {
                count++;
                stack1.Push(count.ToString());
            }
            Console.WriteLine("________________________");
            Console.WriteLine(stack1.Count);

            Console.WriteLine("________________________");

            Console.WriteLine(stack1.Contains("99"));

            

            count = 0;


            while (count < 100)
            {
                count++;
                Console.WriteLine(stack1.Pop());
               
            }
            Console.WriteLine("________________________");
            Console.WriteLine(stack1.Count);
            Console.WriteLine("________________________");



            
            

        }
    }

    
}
