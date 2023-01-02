using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectionExample
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            //Select Example
            List<string> nameList = new List<string> { "Lily", "Alan", "Vivian", "David" }  ;
            
            var selectExample = nameList.Select(a => a);
            //To project the string in the nameList to a new object that contains Name property
            var selectExample2 = nameList.Select(a => new {Name = a});
            foreach (var name in selectExample)
            {
                Console.WriteLine(name);
            }

            //Console.WriteLine(selectExample2.GetType());
            Console.ReadLine();

            //SelectMany Example
            List<Student> students = new List<Student>()
            {
                new Student() {Id = 1, Name = "Lily", Programming = new List<string>() {"C#", "Java", "C++"}},
                new Student() {Id = 1, Name = "Alan", Programming = new List<string>() {"VB.NET", "C"}},
                new Student() {Id = 1, Name = "Vivian", Programming = new List<string>() {"Python", "SQL"}},
                new Student() {Id = 1, Name = "David", Programming = new List<string>() {"C#", "JS", "Angular"}}
            };

            //Method Syntax
            var method = students.SelectMany(student => student.Programming);

            //Query Syntax
            var query = from student in students
                        from language in student.Programming
                        select language;

            foreach (string language in method)
            {
                Console.WriteLine(language);
            }

        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Programming { get; set; }
    }
}