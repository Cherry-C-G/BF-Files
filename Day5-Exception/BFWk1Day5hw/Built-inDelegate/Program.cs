
using System;
using System.Collections.Generic;
using System.Text;

namespace Built_inDelegate
{
    // user-defined delegate
    public delegate void PassExamDelegate(Student student);
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class Exam
    {
        // Output the result based on the student's score
        public void PassExamWithDelegate(Student s)
        {
            if (s.Score >= 60)
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
            (PassExamDelegate d, Student s)
        {
            d(s);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student() { Score = 55, Name = "Sunny" };
            Student student1 = new Student() { Score = 100, Name = "Daisy" };
            Exam exam = new Exam();
            //Console.WriteLine("Result for w/out Delegate: ");
            //exam.PassExamWithoutDelegate(student);
            //exam.PassExamWithoutDelegate(student1);

            Console.WriteLine("Result for w Delegate: ");
            PassExamDelegate d = NewPassExamRule2;
            PassExamDelegate d1 = NewPassExamRule1;
            exam.PassExamWithDelegate(d, student);
            exam.PassExamWithDelegate(d1,student1);

        }

        public static void NewPassExamRule1(Student s)
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
        public static void NewPassExamRule2(Student s)
        {
            if (s.Score >= 60)
            {
                Console.WriteLine("Pass! Score = {0}", s.Score);
            }
            else
            {
                Console.WriteLine("Fail! Score = {0}", s.Score);
            }

        }
    }
}
