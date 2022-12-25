using System;

namespace PolymorphismExample
{
    public class Program
    {
        public  void PrintArea(int x, int y)
        {
            Console.WriteLine(x * y);
        }
        public  void PrintArea(int x)
        {
            Console.WriteLine(x * x);
        }
        public static void PrintArea(int x, double y)
        {
            Console.WriteLine(x * y);
        }
        // Method overloading with different order of same parameters
        public static void PrintArea(double y, int x)
        {
            Console.WriteLine(x * y);
        }
        public static void PrintArea(double x)
        {
            Console.WriteLine(x * x);
        }

        static void Main(string[] args)
        {
            
        }
    }





}
