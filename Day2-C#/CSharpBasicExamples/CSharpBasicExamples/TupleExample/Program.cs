using System;

namespace TupleExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string, int) t1 = ("Liam", 22);
            (string name, int age) t2 = ("Lily", 23);
            Console.WriteLine("Name is " + t1.Item1 + ", " + "Age is " + t1.Item2);
            Console.WriteLine($"Name is {t2.name}, Age is {t2.age}");

        }
    }
}

