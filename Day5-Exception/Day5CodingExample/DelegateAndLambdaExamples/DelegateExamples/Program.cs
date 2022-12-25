using System;

namespace DelegateExamples
{
    //step1: declare
    //declare a delegate with no parameters and no return value
    public delegate void NoParamNoReturnDelegate();
    
    public delegate int OneParamReturnIntDelegate(int num);
    internal class Program
    {
        static void Main(string[] args)
        {
            //step 2: set a target method to the delegate
            NoParamNoReturnDelegate d1 = new NoParamNoReturnDelegate(NoParamNoReturnFunction);

            //another way for step 2
            NoParamNoReturnDelegate d2 = NoParamNoReturnFunction;

            //step3: invoke a delegate
            d1.Invoke();

            //another way for step3
            d2();

            #region Delegate Members in Test class
            Test test = new Test();
           // test.TestFunction(SquareNumber, NoParamNoReturnFunction);
            #endregion
        }

        public static void NoParamNoReturnFunction()
        {
            Console.WriteLine("No params and return void!");
        }

        public static int SquareNumber(int num)
        {
            return num*num;
        }
    }
}
