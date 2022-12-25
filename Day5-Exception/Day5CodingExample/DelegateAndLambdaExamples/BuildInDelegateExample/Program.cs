using System;

namespace BuildInDelegateExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Func<> -- return a result
            //Func with 2 input parameters and one return 
            Func<int, int, int> addNumberDelegate = Sum;
            int result = addNumberDelegate(10, 20);
            Console.WriteLine(result);

            //Func with no input and one return
            Func<bool> returnTrueDelegate = ReturnTrue;
            Console.WriteLine(returnTrueDelegate());

            //Action<> -- return void
            //Action with 2 input parameters and no return
            Action<int, int> printSumDelegate = PrintSum;
            printSumDelegate(1, 2);

            //Predicate<> -- take in one parameter return bool
            Predicate<int> isAdultDelegate = IsAdult;
            Console.WriteLine(isAdultDelegate(18));
        }

        static int Sum(int a , int b)
        {
            return a + b;
        }

        static bool ReturnTrue ()
        {
            return true;
        }

        static void PrintSum(int a, int b)
        {
            Console.WriteLine("The result is: " + a + b);
        }

        static bool IsAdult( int a)
        {
            return a >= 18 ? true : false;
        }
    }
}
