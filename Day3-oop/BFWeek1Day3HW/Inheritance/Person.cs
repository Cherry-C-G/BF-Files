using System;
using System.IO;


namespace Inheritance
{

    public class Person
    {
        // person base class definition
        public String name;
        public String address;
        public String phoneNumber;
        public String emailAddress;
        public Person(String name, String address, String phoneNumber, String emailAddress)
        {
            // constructor for variable initilization
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
        }
    }
    public class Student : Person
    {
        public string status;

        // student class ,child of person
        public enum Status
        {
            Freshman,
            Sophomore,
            Junior,
            Senior
        }
        public Student(String name, String address, String phoneNumber, String emailAddress, String status)
        {
            status = status;
        }
        public String toString()
        {
            // method to override toString method in object class
            return "Student\nName :" + this.name + "\nAddress :" + this.address + "\nPhone number :" + this.phoneNumber + "\nEmail Address :" + this.emailAddress + "\nStatus :" + this.status;
        }
    }
    public class Employee : Person
    {
        // Employee class definition extending Person class
        public int officerNumber;
        public int salary;
        public MyDate date;
        public Employee(String name, String address, String phoneNumber, String emailAddress, int officerNumber, int salary, MyDate date)
        {
            this.officerNumber = officerNumber;
            this.salary = salary;
            this.date = date;
        }
    }
    public class MyDate
    {
        private String date;
        public MyDate(String date)
        {
            this.date = date;
        }
        public String getDate()
        {
            return this.date;
        }
    }
    public class Faculty : Employee
    {
        // Faculty class definition extending Employee class
        public String hours;
        public String rank;
        public Faculty(String name, String address, String phoneNumber, String emailAddress, int officerNumber, int salary, MyDate date, String hours, String rank)
        {
            this.hours = hours;
            this.rank = rank;
        }
        public String toString()
        {
            return "Faculty\nName :" + this.name + "\nAddress :" + this.address + "\nPhone number :" + this.phoneNumber + "\nEmail Address :" + this.emailAddress + "\nOfficer number" + this.officerNumber.ToString() + "\nSalary :" + this.salary.ToString() + "\nDate :" + this.date.getDate() + "\nHours :" + this.hours + "\nRank :" + this.rank;
        }
    }
    public class Staff : Employee
    {
        public String title;
        public Staff(String name, String address, String phoneNumber, String emailAddress, int officerNumber, int salary, MyDate date, String title)
        {
            this.title = title;
        }
        public String toString()
        {
            return "Staff\nName :" + this.name + "\nAddress :" + this.address + "\nPhone number :" + this.phoneNumber + "\nEmail Address :" + this.emailAddress + "\nOfficer number :" + this.officerNumber.ToString() + "\nSalary :" + this.salary.ToString() + "\nDate :" + this.date.getDate() + "\nTitle :" + this.title;
        }
    }
    // Driver class for defining main method
    public class TestDriver
    {
        public static void Main(String[] args)
        {
            String name;
            String address;
            String phone;
            String email;
            var s = "Inputs";
            Console.WriteLine("What type of object you want??");
            Console.WriteLine("1.Student\n2.Faculty\n3.Staff\nEnter their corresponding number(1 or 2 or 3)");
            var op = Convert.ToInt64(Console.ReadLine());
            var sc = "Inputs";
            Console.WriteLine("Enter name :");
            name = Console.ReadLine();
            Console.WriteLine("Enter Address :");
            address = Console.ReadLine();
            Console.WriteLine("Enter phone number :");
            phone = Console.ReadLine();
            Console.WriteLine("Enter mail address :");
            email = Console.ReadLine();
            switch (op)
            {
                case 1:
                    // Scanner sc=new Scanner(System.in);
                    Console.WriteLine("Enter student status");
                    var status = Console.ReadLine();
                    var st = new Student(name, address, phone, email, status);
                    Console.WriteLine(st.toString());
                    break;
                case 2:
                    Console.WriteLine("Enter officer number");
                    var officerNumber = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter salary");
                    var salary = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter Date");
                    var date = Console.ReadLine();
                    var dt = new MyDate(date);
                    Console.WriteLine("Enter number of hours worked :");
                    var hrs = Console.ReadLine();
                    Console.WriteLine("Enter Rank :");
                    var rank = Console.ReadLine();
                    var f = new Faculty(name, address, phone, email, (int)officerNumber,(int) salary, dt, hrs, rank);
                    Console.WriteLine(f.toString());
                    break;
                case 3:
                    Console.WriteLine("Enter officer number");
                    var officerNumber_s = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter salary");
                    var salary_s = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter Date");
                    var date_s = Console.ReadLine();
                    var dt_s = new MyDate(date_s);
                    Console.WriteLine("Enter title of staff");
                    var title = Console.ReadLine();
                    var staff = new Staff(name, address, phone, email, (int)officerNumber_s, (int)salary_s, dt_s, title);
                    Console.WriteLine(staff.toString());
                    break;
            }
        }
    }

}