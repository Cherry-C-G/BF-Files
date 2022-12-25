using System;

namespace ThrowExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = null;
           // student = new Student() { Id = 101, Name = "Lee"};
            try
            {
                Greeting(student);
            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        private static void Greeting(Student s)
        {
           
            // if the student is null, throw Exception
            if (s == null)
            {
                throw new ArgumentNullException();
            }
             
            //if the student is not null, show Hello and the name in console;
            Console.WriteLine("Hello " + s.Name);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
