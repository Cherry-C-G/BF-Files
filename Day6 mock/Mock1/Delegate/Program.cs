
//Write a delegate and pass the delegate as a function parameter:
//Create a public delegate called OperationDelegate, it takes two arguments with float type and returns a float value as well;
//Create 4 public static methods: Add, Subtract, Multiply, and Divide.All of them should take 2 arguments and return a float that corresponds to the result of the performed operation;
//Create a static ApplyOperation method that takes in 2 floats and one OperationDelegate and applies the operation to those values;
//Call the ApplyOperation method in the Main() and perform Add, Subtract, Multiply and Divide operations
//You can create a delegate on your own or use the built-in generic delegate with lambda expressions to fulfill the task.


namespace Delegate
{

    public delegate float OperationDelegate(float x, float y);

    public static class Calculator
    {
        public static float Add(float x, float y)
        {
            return x + y;
        }

        public static float Subtract(float x, float y)
        {
            return x - y;
        }

        public static float Multiply(float x, float y)
        {
            return x * y;
        }

        public static float Divide(float x, float y)
        {
            return x / y;
        }

        public static float ApplyOperation(float x, float y, OperationDelegate operation)
        {
            return operation(x, y);
        }

        public static void Main(string[] args)
        {
            // addition
            float result = Calculator.ApplyOperation(5, 3, (x, y) => x + y);
            Console.WriteLine("Result of addition: " + result);

            // subtraction
            result = Calculator.ApplyOperation(5, 3, (x, y) => x - y);
            Console.WriteLine("Result of subtraction: " + result);

            // multiplication
            result = Calculator.ApplyOperation(5, 3, (x, y) => x * y);
            Console.WriteLine("Result of multiplication: " + result);

            // division
            result = Calculator.ApplyOperation(5, 3, (x, y) => x / y);
            Console.WriteLine("Result of division: " + result);
        }


    }

}