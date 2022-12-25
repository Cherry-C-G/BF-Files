using System;
using System.Collections;

namespace week1day2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test the calculator with the example input
            int[] input1 = { 5, 6, 14, 7 };
            string[] input2 = { "Add", "Sub", "Div" };
            Console.WriteLine(Calculate(input1, input2)); 
        }

        static int Calculate(int[] input1, string[] input2)
        {
            // Initialize the result to the first value in the input array
            int result = input1[0];

            // Loop through the operator array
            for (int i = 0; i < input2.Length; i++)
            {
                // Get the next value in the input array
                int value = input1[i + 1];

                // Perform the corresponding operation
                switch (input2[i])
                {
                    case "Add":
                        result += value;
                        break;
                    case "Sub":
                        result -= value;
                        break;
                    case "Mul":
                        result *= value;
                        break;
                    case "Div":
                        result /= value;
                        break;
                }
            }

            return result;
        }
    }





}

