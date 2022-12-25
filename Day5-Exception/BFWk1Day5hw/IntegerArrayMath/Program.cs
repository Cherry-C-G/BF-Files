//3.Create the IntegerArrayMath class with int division method:
//A.Loops thru instance field array and attempts to divide each value of the number array
//by the corresponding value of denom instance field array. such as number[0]/ denom[0]
//and number[1]/denom[1],etc
//B.If the result of the division is an integer then print out a message indicating the result
//of the division such as 8/4 is 2.
//C.If the result of the division is not an integer then throw and handle a
//NonIntResultException and continue processing the result of the number array
//elements.
//D.The method should use exception handling and also handle any attempt to divide by
//zero(arithmetic exception) the program should display an appropriate message and
//then continue processing the rest of the number array elements
//E.Assume both arrays are the same length.
//Examples:
//Input:
//Number is [4,8,15] and denom is [2,0,4]
//Output:
//The resultant output would be: 4/2 is 2
//Division by zero is undefined
//result 15 divided by 4 is not an integer





using System;

namespace IntegerArrayMath
{
    public class IntegerArrayMath
    {
        private readonly int[] _number;
        private readonly int[] _denom;

        public IntegerArrayMath(int[] number, int[] denom)
        {
            _number = number;
            _denom = denom;
        }

        public void Division()
        {
            for (int i = 0; i < _number.Length; i++)
            {
                try
                {
                    if (_denom[i] == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    if (_number[i] % _denom[i] == 0)
                    {
                        Console.WriteLine("{0} / {1} is {2}", _number[i], _denom[i], _number[i] / _denom[i]);
                    }
                    else
                    {
                        throw new NonIntResultException(_number[i], _denom[i]);
                    }
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Division by zero is undefined");
                }
                catch (NonIntResultException ex)
                {
                    Console.WriteLine("result {0} divided by {1} is not an integer", _number[i], _denom[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] number = { 4, 8, 15 };
            int[] denom = { 2, 0, 4 };

            IntegerArrayMath math = new IntegerArrayMath(number, denom);
            math.Division();

        }
    }
}
