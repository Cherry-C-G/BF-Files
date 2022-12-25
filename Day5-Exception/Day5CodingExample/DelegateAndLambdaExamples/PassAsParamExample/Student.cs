using System;
using System.Collections.Generic;
using System.Text;

namespace PassAsParamExample
{
    // user-defined delegate
    public delegate void PassAsParamExampleDelegate(Student student);
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class Exam
    {
        // Output the result based on the student's score
        public void PassExamWithoutDelegate (Student s)
        {
            if (s.Score >= 70)
            {
                Console.WriteLine("Pass! Score = {0}", s.Score);
            }
            else
            {
                Console.WriteLine("Fail! Score = {0}", s.Score);
            }


        }

        // Output the result based on the student's score using Delegate
        public void PassExamWithDelegate 
            (PassAsParamExampleDelegate d, Student s)
        {
            d(s);
        }
    }
}
