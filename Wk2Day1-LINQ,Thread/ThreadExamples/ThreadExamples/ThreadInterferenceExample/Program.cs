using System;
using System.Threading;

namespace ThreadInterferenceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            counter.Increment();
            counter.Decrement();
            Console.WriteLine("Only Main Thread works on the counter --> " + counter.Value);

            //Thread Interference Example
            Thread t1 = new Thread(() => counter.Increment());
            Thread t2 = new Thread(() => counter.Decrement());
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("Two Threads works on the counter --> " + counter.Value);
        }
    }

    class Counter
    {
        public int Value { get; set; } = 0;

        public void  Increment()
        {
            lock (this) 
            {
                for (int i = 0; i < 100_000; i++)
                {
                    Value++;
                }
            }
               

        }

        public void Decrement()
        {
            lock (this) 
            {
                for (int i = 0; i < 100_000; i++)
                {
                    Value--;
                }
            }

            
        }
    }
}
