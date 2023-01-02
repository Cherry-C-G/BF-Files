using System;
using System.Threading;

namespace MainThreadExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread start: ");
            Thread.Sleep(1000);
            Console.WriteLine("HelloWorld!");
            Thread.Sleep(3000);
            Console.WriteLine("HelloWorld!");
            Thread.Sleep(5000);
            Console.WriteLine("HelloWorld!");
        }
    }
}
