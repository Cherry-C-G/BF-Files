using System;

namespace print_table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //. (Print a table) Write a program that displays the following table a b pow(a,b)
            int baseNumber, expNumber;
            Console.Write("Base Number : ");
            baseNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("exponent Number : ");
            expNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("a\tb\tpow(a,b)\n");


            for (int i = 1; i <= expNumber; i++)
            {
               
                Console.WriteLine(" {0}{1}{2}", baseNumber, expNumber, Math.Pow(baseNumber,expNumber));


            }


        }
    }
}