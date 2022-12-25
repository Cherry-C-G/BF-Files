namespace PrintNumberInWord
{
	//switch
	//public class Program
	//{
	//    static void Main(string[] args)
	//    {
	//        Console.Write("Enter a number between 1 and 9: ");

	//        int number = Convert.ToInt32(Console.ReadLine());

	//        int PrintNumberInWord = number;

	//        switch (PrintNumberInWord)
	//        {

	//            case 1:
	//                Console.WriteLine("ONE");
	//                break;
	//            case 2:
	//                Console.WriteLine("TWO");
	//                break;
	//            case 3:
	//                Console.WriteLine("THREE");
	//                break;
	//            case 4:
	//                Console.WriteLine("FOUR");
	//                break;
	//            case 5:
	//                Console.WriteLine("FIVE");
	//                break;
	//            case 6:
	//                Console.WriteLine("SIX");
	//                break;
	//            case 7:
	//                Console.WriteLine("SEVEN");
	//                break;
	//            case 8:
	//                Console.WriteLine("EIGHT");
	//                break;
	//            case 9:
	//                Console.WriteLine("NINE");
	//                break;
	//            default:
	//                Console.WriteLine("OTHER");
	//                break;
	//        }
	//    }
	//}

	/* C# program to print a given number in words.
The program handles till 9 digits numbers and
can be easily extended to 20 digit number */

	//if statement
	using System;
	class program
	{

		// strings at index 0 is not used, it is
		// to make array indexing simple
		static string[] one = { "", "one ", "two ", "three ", "four ",
							"five ", "six ", "seven ", "eight ",
							"nine ", "other " };

		// strings at index 0 and 1 are not used,
		// they are to make array indexing simple
		static string[] ten = { "", "", "twenty ", "thirty ", "forty ",
							"fifty ", "sixty ", "seventy ", "eighty ",
							"ninety " };

		// n is 1- or 2-digit number
		static string numToWords(int n, string s)
		{
			string str = "";

			// if n is more than 19, divide it
			if (n > 19)
			{
				str += ten[n / 10] + one[n % 10];
			}
			else
			{
				str += one[n];
			}

			// if n is non-zero
			if (n != 0)
			{
				str += s;
			}

			return str;
		}

		// Function to print a given number in words
		static string convertToWords(long n)
		{

			// stores word representation of
			// given number n
			string out1 = "";

			// handles digits at ten millions and
			// hundred millions places (if any)
			out1 += numToWords((int)(n / 10000000),
							"crore ");

			// handles digits at hundred thousands
			// and one millions places (if any)
			out1 += numToWords((int)((n / 100000) % 100),
							"lakh ");

			// handles digits at thousands and tens
			// thousands places (if any)
			out1 += numToWords((int)((n / 1000) % 100),
							"thousand ");

			// handles digit at hundreds places (if any)
			out1 += numToWords((int)((n / 100) % 10),
							"hundred ");

			if (n > 100 && n % 100 > 0)
			{
				out1 += "and ";
			}

			// handles digits at ones and tens
			// places (if any)
			out1 += numToWords((int)(n % 100), "");

			return out1;
		}

		// Driver code
		static void Main()
		{
            Console.Write("Enter a number between 1 and 9: ");

            int number = Convert.ToInt32(Console.ReadLine());

            int PrintNumberInWord = number;

            // long handles upto 9 digit no
            // change to unsigned long long int to
            // handle more digit number
           // long n = 438237764;

			// convert given number in words
			Console.WriteLine(convertToWords(number));
		}
	}

	// This code is contributed by mits

}