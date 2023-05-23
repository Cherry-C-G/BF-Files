//Practice 2: C#
//Develop a program/method to generate the greeting (Console Application)
//Input: Your program accepts your name(string)
//Output: Your program should return Greeting message based on current time. Example: input / output
//Input: “Satya” Output: “Hello Satya, Good Afternoon!” (it differs 

using System;

namespace GreetingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            string greeting = GenerateGreeting(name);

            Console.WriteLine(greeting);
        }

        static string GenerateGreeting(string name)
        {
            DateTime now = DateTime.Now;
            string timeOfDay;

            if (now.Hour >= 0 && now.Hour < 12)
            {
                timeOfDay = "Good Morning";
            }
            else if (now.Hour >= 12 && now.Hour < 17)
            {
                timeOfDay = "Good Afternoon";
            }
            else
            {
                timeOfDay = "Good Evening";
            }

            return $"Hello {name}, {timeOfDay}!";
        }
    }
}
