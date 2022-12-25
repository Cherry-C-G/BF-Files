using System;

namespace ConversionsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conversion Examples");

            //Conversions
            int myInt = 100;
            long myLong = myInt; // int -> long
            double myDouble = myInt; // int -> double
            Console.WriteLine(myLong);
            Console.WriteLine(myDouble);

            myInt = 'A'; // char -> int
            Console.WriteLine(myInt);

            //Casting
            int result = (int)(8.0 / 3.0); // double -> int
            Console.WriteLine(result);

            myLong = 2_147_483_648; // the largest number that an int variable can hold is 2_147_483_647
            myInt = (int)myLong;
            Console.WriteLine(myInt);

            

        }
    }
}
