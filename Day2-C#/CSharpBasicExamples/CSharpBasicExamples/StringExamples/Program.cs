using System;

namespace StringExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region String Declaration
            //Console.WriteLine("String Declaration:");
            //string sayHi = "Hello December!";
            ////we can use index to access every char in the string
            //char oneChar = sayHi[0];
            //Console.WriteLine(oneChar); // H
            //#endregion
            
 
            #region String Interning
            Console.WriteLine("String Interning");
            string s1 = "Hello";
            s1 += "O"; // s1 = "HelloO";
            string s2 = "Hello";
            string s3 = new string("Hello");
            Console.WriteLine(s1 == s2); // compare the value of s1 and s2
            Console.WriteLine(ReferenceEquals(s1, s2)); // compare the reference of s1 and s2 // true
            //Console.WriteLine(s2 == s3);
            //Console.WriteLine(ReferenceEquals(s2, s3)); // compare the reference of s2 and s3
            #endregion

            //#region String Manipulation
            //Console.WriteLine("String Manipulation:");
            //// string concatenation -> +
            //string str1 = "New";
            //string str2 = "Jersey";
            //string combinedString1 = str1 + str2;
            //Console.WriteLine(combinedString1); // NewJersey

            ////string concatenation -> Concat()
            //string combinedString2 = string.Concat(str1, str2);
            //Console.WriteLine(combinedString2); // NewJersey

            ////string interpolation
            //string stringInterpolation = $"{combinedString2} is the garden state.";
            //Console.WriteLine(stringInterpolation);

            ////string formatting
            //(string name, int age) myInfo = ("Liam", 22);
            //Console.WriteLine("Hello, I am {0}, {1} years old.", myInfo.name, myInfo.age);
            //#endregion
        }
    }
}
