//Practice 1: C#
//Develop a program/method (console application) to do basic calculations. Input: Your program accepts two inputs (value1, value2)
//Input: You program accept options like 1(sum of two values), 2(subtraction of 2 values), 3(multiplication of two values)
//Output: for the given two inputs, based on the option you choose it should produce the results
//Example: input / output
//Input: value1 = 10, value = 20
//Input option: 1
//Output: 30
using System;

namespace BasicCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user for two values
            Console.Write("Enter the first value: ");
            double value1 = double.Parse(Console.ReadLine());

            Console.Write("Enter the second value: ");
            double value2 = double.Parse(Console.ReadLine());

            // Prompt the user for the operation to perform
            Console.Write("Choose an operation (1 for addition, 2 for subtraction, 3 for multiplication): ");
            int operation = int.Parse(Console.ReadLine());

            // Perform the selected operation and output the result
            double result;
            switch (operation)
            {
                case 1:
                    result = value1 + value2;
                    Console.WriteLine("The sum of {0} and {1} is {2}.", value1, value2, result);
                    break;
                case 2:
                    result = value1 - value2;
                    Console.WriteLine("The difference between {0} and {1} is {2}.", value1, value2, result);
                    break;
                case 3:
                    result = value1 * value2;
                    Console.WriteLine("The product of {0} and {1} is {2}.", value1, value2, result);
                    break;
                default:
                    Console.WriteLine("Invalid operation selected.");
                    break;
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
