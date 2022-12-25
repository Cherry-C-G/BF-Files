using System;

namespace ObjectOrientedExample
{
    public enum Gender
    {
        Man,
        Woman
    }
    public class Employee
    {
        //Fields - to describe the state of Employee 
        public string _name;
        public int _age;
        public Gender _gender;
        public Employee _manager;

        //default constructor
        public Employee() { }

        //a constructor that can initialize name, age and gender fields
        public Employee(string name, int age, Gender gender)
        {
            _name = name;
            _age = age;
            _gender = gender;
        }

        //Methods - to describe the behavior of Employee
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
    //Extension class
    static class ExtensionForEmployee
    {
        public static void OpenTheDoor(this Employee value)
        {
            Console.WriteLine("Door Opened...");
        }

        public static void MorningGreeting(this Employee value, string empName)
        {
            Console.WriteLine($"Good Morning, {empName}!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //use default constructor to instanciate an object called rose
            Employee rose = new Employee();
            // rose._name = "Rose";
            Console.WriteLine(rose._gender);
            //rose._gender = Gender.Woman;
            rose._age = 22;
            rose.SayHello();
            //use the parameterized constructor to instanciate an object of Employee class called jack
            Employee jack = new Employee("Jack", 23, Gender.Man);
            Console.WriteLine("Employee name: {0}, age: {1}, gender: {2}", jack._name, jack._age, jack._gender);


            //Property Example
            People tommy = new People();
            tommy.Name = "Tommy"; // use property to set the name of People
            Console.WriteLine(tommy.Name); // use property to get the name of People
            //tommy.WorkingHoursPerDay = 15; // this property is read only, we cannot modify it
            Console.WriteLine(tommy.WorkingHoursPerDay);

            //Extension Method
            Employee han = new Employee("Han", 32, Gender.Man);
            han.OpenTheDoor();
            han.MorningGreeting("Mark");
           
        }
    }
}


