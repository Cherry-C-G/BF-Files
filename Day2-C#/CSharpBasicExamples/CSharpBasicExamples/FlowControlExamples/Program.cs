using System.Reflection.Metadata;

namespace FlowControlExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region Switch Statement
            ////switch statement
            //double measurement = 22.5;

            //switch (measurement)
            //{
            //    // (Introduced in C# 9.0)
            //    case < 0.0:
            //        Console.WriteLine($"Measured value is {measurement}; too low.");
            //        break;

            //    case > 15.0:
            //        Console.WriteLine($"Measured value is {measurement}; too high.");
            //        break;

            //    default:
            //        Console.WriteLine($"Measured value is {measurement}.");
            //        break;
            //}

            //char letter = 'A';
            //switch (letter)
            //{
            //    case 'A':
            //        Console.WriteLine("Letter A");
            //        break;

            //    case 'B':
            //        Console.WriteLine("Letter B");
            //        break;

            //    default:
            //        Console.WriteLine("A Letter");
            //        break;
            //}
            //#endregion

            //Goto Statement
            int apple = 0;
            Console.WriteLine("You don't have an apple.");
            
        //label
        more:
            Console.WriteLine("You get an apple.");
            apple++;

            if (apple <= 5)
            {
                Console.WriteLine($"You have {apple} apple(s), you need more!");
                goto more; // will goto the label

            }

            Console.WriteLine("Now you have enough apples!");

        }
    }
}