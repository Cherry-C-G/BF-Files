using System;
using System.Threading;

namespace JoinMethodExample
{
    internal class Program
    {
        static Thread thread1, thread2, thread3;
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started");

            //Main Thread creating three child threads
            thread1 = new Thread(Method1);
            thread2 = new Thread(Method2);
            thread3 = new Thread(Method3);

            thread1.Start();
            thread2.Start();
            thread3.Start();

          thread1.Join(); //Block Main Thread until thread1 completes its execution
           thread2.Join(); //Block Main Thread until thread2 completes its execution
          thread3.Join(); //Block Main Thread until thread3 completes its execution

            Console.WriteLine("Main Thread Ended");
        }
        static void Method1()
        {

            Console.WriteLine("Method1 - Thread1 Started");
            Thread.Sleep(2000);
            Console.WriteLine("Method1 - Thread 1 Ended");
        }

        static void Method2()
        {
            thread1.Join();
            Console.WriteLine("Method2 - Thread2 Started");
            Thread.Sleep(2000);
            Console.WriteLine("Method2 - Thread2 Ended");
        }

        static void Method3()
        {
            thread2.Join();
            Console.WriteLine("Method3 - Thread3 Started");
            Thread.Sleep(2000);
            Console.WriteLine("Method3 - Thread3 Ended");
        }
    }
}
