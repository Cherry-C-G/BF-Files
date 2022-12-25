using System;
using System.Text;

namespace FinallyExamples
{
    internal class Program
    {
       private StringBuilder sb = new StringBuilder("OgString");
        
        //Display the string in the StringBuilder
        private void DisplayString()
        {
            Console.WriteLine(sb.ToString());
        }
        private void MethodOne()
        {
            try
            {
                sb.Append(" + TryOne");
                MethodTwo();
            }
            catch (Exception)
            {
                sb.Append(" + CatchOne");
            }
        }

       private void MethodTwo()
        {
            try
            {
                throw new ArithmeticException();
            }
            catch (ArithmeticException)
            {
                throw new Exception();
            }
            finally
            {
                sb.Append(" + FinallyTwo");
            }

            sb.Append(" + Message in MethodTwo");
        }

        static void Main(string[] args)
        {
            #region Example ①&② control leaves try
            try
            {
                Console.WriteLine("Please enter a number to divide 100: ");
                //We want to get the user input here, and parse the interger in the string
                int userInput = int.Parse(Console.ReadLine());

                int result = 100 / userInput;

                Console.WriteLine("100 / {0} = {1}", userInput, result);
            }
            catch (Exception)
            {
                Console.WriteLine("Catch block was executing");
            }
            finally
            {
                Console.WriteLine("Finally block was executing");
            }
            #endregion

            Program program = new Program(); // create a program object to call the methods

            #region Example ③ return or break statement
            program.ReturnMethod();
            #endregion

            #region Example ④: propagation

            program.MethodOne();
            program.DisplayString();
            #endregion
        }

        private void ReturnMethod()
        {
            try
            {
                Console.WriteLine("ReturnMethod was executing");
                return;
            }
            finally // we can also use try-finally without catch
            {
                Console.WriteLine("We can use try-finally");
            }
        }


    }
}
