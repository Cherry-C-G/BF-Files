namespace TryCatchExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a number to divide 100: ");
                //We want to get the user input here, and parse the interger in the string
                int userInput = int.Parse(Console.ReadLine());

                int result = 100 / userInput;

                Console.WriteLine("100 / {0} = {1}", userInput, result);

            }

            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Over flow");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }

            //The code after exception handling
            Console.WriteLine("The Program Keep executing");

        }

    }
}