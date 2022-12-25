using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OccurrenceOfMaxNum
{
    class Program
    {
        static void Main()
        {
            int i = 0;
            int count = 0;
            int item = 0;

            int[] arr1 = new int[7];

            //Read numbers into array
            Console.WriteLine("Enter numbers : ");
            for (i = 0; i < 7; i++)
            {
                Console.Write("Enter numbers[" + (i + 1) + "]: ");
                arr1[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter item : ");
            item = int.Parse(Console.ReadLine());

            for (i = 0; i <7; i++)
            {
                if (item == arr1[i])
                {
                    count++;
                }
            }

            Console.WriteLine("The largest number is" + item + " The occurrence count of the largest number is : " + count);

            Console.WriteLine();
        }
    }
}
