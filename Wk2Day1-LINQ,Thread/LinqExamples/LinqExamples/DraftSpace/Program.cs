using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DraftSpace
{
    class Student 
    {
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "abc";
            List<int> nums = new List<int>() { 1,2,3,4,5};
            int num = 2;

            Student s = new Student();
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }

        }
    }
}
