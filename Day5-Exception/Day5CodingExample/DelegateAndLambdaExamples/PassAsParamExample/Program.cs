using System;

namespace PassAsParamExample
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student() { Score = 60, Name = "Alan" };
            Student student2 = new Student() { Score = 82, Name = "Lily" };
            Exam exam = new Exam();
            Console.WriteLine("Result for w/out Delegate: ");
            //exam.PassExamWithoutDelegate(student1);

            Console.WriteLine("Result for w Delegate: ");
            PassAsParamExampleDelegate d = NewPassExamRule1;
            PassAsParamExampleDelegate d2 = NewPassExamRule2;
            exam.PassExamWithDelegate(d2, student2);

        }

        public static void NewPassExamRule1 (Student s)
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
            if (s.Score >= 90)
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
