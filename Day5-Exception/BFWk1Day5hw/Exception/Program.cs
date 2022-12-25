




//2. Create a user-defined exception class called NonIntResultException which is
//generated when the result of dividing two integers values produces a result with a
//fractional component [i.e the result is not an integer]
//• NonIntResultException contains:
//• Generates an appropriate message, for example, if the two integers are 7 and 2 . the
//resulting exception message would be “7 divided by 2 is not an integer”



using System;

namespace CustomExceptions
{
    public class NonIntResultException : Exception
    {
        public NonIntResultException(): base() { }
        public NonIntResultException(int x, int y)
            : base(String.Format("{0} divided by {1} is not an integer", x, y))
        {
        }


    }

    public class Program
    {
        static void Main(string[] args)
        {
            int x = 7;
            int y = 2;
            try
            {
                if (x % y != 0)
                {
                    throw new NonIntResultException(x, y);
                }
            }
            catch (NonIntResultException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}
