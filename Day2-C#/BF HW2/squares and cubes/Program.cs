using System;

namespace squares_and_cubes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //           3. Using only the programming techniques you learned in this lesson, write an
            //application that calculates the squares and cubes of the numbers from 0 to 10 and
            //prints the resulting values in a table format, as shown below. (Build -in functions are not
            //acceptable) number square cube
            int i, ctr;
            Console.Write("Input a number from 0 to 10:");
            ctr = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number\tSquare\tCube\n");

            for (i = 0; i <= ctr; i++)
                //int square = number * number;
                Console.WriteLine("{0} {1} {2}",i, (i * i), (i * i * i));
            
        }
    }
}