//Practice 3: C#
//Develop a program/method to print sum of the digits

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();

        int sum = 0;
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                int digit = int.Parse(c.ToString());
                sum += digit;
            }
        }

        Console.WriteLine($"The sum of the digits is: {sum}");
    }
}
