using System;

namespace ExtensionMethodExample
{
    public static class ExtensionClass
    {
        // an extension method for MyInteger class
        public static int  TripleValue(this MyInteger mi, int value) //this is an Idenfifier for extension method, it also represents the current object
        {
            Console.WriteLine(mi.Num); // print out the current instance's Num value
            mi.DoubleTheValue(5);// we can use current object to call non-static method
            MyInteger.ToAHundred(); // we can also use the class to call the non-static method
            return value * 3;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {    
            MyInteger myInt = new MyInteger();
            myInt.Num = 100;
            int result = myInt.TripleValue(3);
            Console.WriteLine(result);
        }
    }
}
