using System;
using System.Threading;
namespace CreateThreadExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //Step1: Create an instance of Thread  
            Thread t1 = new Thread(PrintHelloWorld);

            //ThreadStart tsDelegate = new ThreadStart(PrintHelloWorld);
            //Thread t1 = new Thread(tsDelegate);
            //Thread t1 = new Thread(() => Console.WriteLine("Hello Lambda!"));
           
            t1.Start();
         
            Thread t2 = new Thread(PrintNumber);

            //Step2: Run the Thread by calling the Start() method
            //the parameter should be passed in the Start() method
             t2.Start(5);

            Console.WriteLine("Main thread is here");
        }

        static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World");
        }

        //the input datatype of the ParameterizedThreadStart is an object type,
        //and you cannot change the data type from object to any other type
        static void PrintNumber(object num)
        {
            Console.WriteLine(Convert.ToInt32(num));
        }
        static void One() 
        {
        
        }


    }
}
