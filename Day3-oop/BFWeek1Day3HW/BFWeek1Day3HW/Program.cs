using System;


namespace BFWeek1Day3HW
{

    //1.	Write an extension method for string type, to change all the letters in the calling string to upper cases.



    public class Program
    {

        static void Main(string[] args)
        {
           string s = "Today is a good day";
            string upper = s.ToUpper();
            Console.WriteLine(upper);
        }
    }

    public static class Extensions
    {
        public static void ToUpper(this string message)
        {
            Console.WriteLine(message);
        }
    }

}