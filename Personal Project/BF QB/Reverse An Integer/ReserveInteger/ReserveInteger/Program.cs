

using System;
public class ReverseInteger
{
    public static void Main ( String [] args)
    {
        TestReverse();
    }
    public static void TestReverse()
    {
        int test1 = 456;
        int expected1 = 654;
        int test2 = -123;
        int expected2 = -321;
        int test3 = 100;
        int expected3 = 1;
        int test4 = 0;
        int expected4 = 0;

        if (Reverse(test1)==expected1&&
            Reverse(test2)==expected2&&
            Reverse(test3) == expected3 &&
            Reverse(test4) == expected4)
        {
            Console.WriteLine("All reverse test cases passed.");
        }
        else
        {
            Console.WriteLine("\"One or more reverse test cases failed.");
        }
    }
    
    public static int Reverse( int number)
    {
        int reversed = 0;
        while(number != 0)
        {
            int remainder = number % 10;
            reversed = reversed * 10 + remainder;
            number /= 10;
        }
        return reversed;
    }

}

//This method takes an integer number as an input and returns its reversed form.
//It initializes a variable reversed to 0 and uses a while loop to iterate through the digits of the input number.
//In each iteration, it multiplies reversed by 10 and adds the remainder of Number divided by 10.
//Then, it updates number by dividing it by 10. The loop continues until number becomes 0. Finally, it returns the reversed integer.
//https://stackoverflow.com/questions/2040702/how-to-reverse-a-number-as-an-integer-and-not-as-a-string,
//https://www.geeksforgeeks.org/write-a-program-to-reverse-digits-of-a-number/# ,
//https://www.geeksforgeeks.org/reverse-digits-integer-overflow-handled/

//ITERATIVE WAY 

//Algorithm:

//Input: num
//(1) Initialize rev_num = 0
//(2) Loop while num > 0
//     (a) Multiply rev_num by 10 and add remainder of num  
//          divide by 10 to rev_num
//               rev_num = rev_num*10 + num%10;
//(b)Divide num by 10
//(3) Return rev_num
//Example: 

//num = 4562
//rev_num = 0
//rev_num = rev_num * 10 + num % 10 = 2
//num = num / 10 = 456
//rev_num = rev_num * 10 + num % 10 = 20 + 6 = 26
//num = num / 10 = 45
//rev_num = rev_num * 10 + num % 10 = 260 + 5 = 265
//num = num / 10 = 4
//rev_num = rev_num * 10 + num % 10 = 2650 + 4 = 2654
//num = num / 10 = 0

//Time Complexity: O(log10 n), where n is the input number. 
//Auxiliary Space: O(1)

//or can convert number into string, then used ReverseString() method to reverse the string, then convert the string back to integer.


//using System;

//public class solution
//{

//    public static string ReverseString(string s)
//    {
//        char[] array = s.ToCharArray();
//        Array.Reverse(array);
//        return new string(array);
//    }

//    static int reversDigits(int num)
//    {
//        // converting number to string
//        string strin = num.ToString();

//        // reversing the string
//        strin = ReverseString(strin);

//        // converting string to integer
//        num = int.Parse(strin);

//        // returning integer
//        return num;
//    }


//    static public void Main()
//    {
//        int num = 4562;
//        Console.Write("Reverse of no. is "
//                    + reversDigits(num));
//    }
//}


//Time Complexity: O(log10n) where n is the input number
//Auxiliary Space: O(1)