using System;
using System.IO;
using System.Net.Http.Headers;

namespace ConsoleApp11_decorator__
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream a = new DecoratorForFileStream(new FileStream("xxx.txt",FileMode.Open),FileMode.Open);
        }
    }
}
