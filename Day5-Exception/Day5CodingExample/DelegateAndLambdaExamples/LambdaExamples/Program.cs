using System;

namespace LambdaExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Deelegate without Lambda
            Test test = new Test();
            Func<int, int, int> addNumber = test.AddTwoNumbers;
            addNumber(2, 3);

            //Delegate with Lambda
            Func<int, int, int> addNumberLambda = (x, y) => x + y;
            addNumberLambda(2, 3);

            Console.WriteLine(addNumber(2,3) == addNumberLambda(2,3));

            
        }
    }
}
