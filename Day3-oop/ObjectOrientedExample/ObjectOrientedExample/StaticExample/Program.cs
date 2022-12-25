using System;
using System.Runtime.CompilerServices;

namespace StaticExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // we can use the class to access the static member without initializing an object
            Student.school = "High School";
            Console.WriteLine(Student.school);

            // we can access the instance variable using object
            Student student1 = new Student();
            student1.name = "Liam";

            Student.StaticMethod();
            student1.ModifySchool();

        }
    }

    public class Student
    {
        // static variable(class variable)
        public static string school;
        // non-static variable (instance variable)
        public string name;

        
        public void ModifySchool()
        {
            school = "New School"; //non-static method can modify static variable

            StaticMethod(); // non-static method can call static method
        }

        public static void StaticMethod()
        {
            //Console.WriteLine(name); // we are not able to access a non-static variable in static method;

            //ModifySchool(); // we cannot call a non-static method in a static method

            Console.WriteLine(school); // we can access static member variable using static method;

        }
    }
}
