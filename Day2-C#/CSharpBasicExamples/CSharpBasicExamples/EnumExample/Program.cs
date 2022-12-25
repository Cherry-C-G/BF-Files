using System;

namespace EnumExample
{
    enum Week
    {
        Monday = 100,     // 100
        Tuesday = 300,    // 300
        Wednesday,  // 301
        Thursday = 500,   // 500
        Friday,     // 4
        Saturday,   // 5
        Sunday      // 6
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enum Example!");

            //an enum value can be access by using the [enum_name].[member_name]
            Week week = Week.Monday;
            Console.WriteLine(week); //Monday
            

            ////we can also access thru the underlying number
           int enumNum = (int)Week.Sunday;
            Console.WriteLine(enumNum);
            Console.WriteLine((Week)4);
        }
    }
}
