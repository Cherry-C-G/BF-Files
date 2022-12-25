using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//b.Write a function/method to reverse a string, ex “Hello” → “olleH”
namespace BF_Day1HW
{
    public class ReverseString
    {
        public static void Main(string[] args)
        {
            //a.Print out “Hello World”;
            Console.WriteLine("Hello, World!");


            string inputString;

            Console.WriteLine("Input string is: " );
            inputString = Console.ReadLine();
            char[] array = inputString.ToCharArray();
            Array.Reverse(array);
            Console.WriteLine(new String(array));
            Console.ReadLine();
        }
    }
}
