using System;
using System.Threading;
namespace ThreadTypesExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mian Thread Start");
            //Define 2 Thread t1 is Foreground Thread, but T2 is Background Thread:
            Thread t1, t2;
            
            t1 = new Thread(
                () => 
            { 
                Thread.Sleep(3000);
                Console.WriteLine("I am a Foreground Thread!");
             }
            );

            t2 = new Thread(
                () => 
            {
                Thread.Sleep(5000);
                Console.WriteLine("I am a Background Thread!");
            }
            );

            t2.IsBackground = true; // set the IsBackground to true to make the thread a background thread

            t1.Start();
            t2.Start();
            //t2.Join();

            Console.WriteLine("Main Thread Ends");
        }
    }
}
