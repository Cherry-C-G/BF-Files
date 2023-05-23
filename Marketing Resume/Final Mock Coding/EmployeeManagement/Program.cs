//Practice 6: C#
//Develop a program to build Employee Management
//Instructions:
//Create an Enum (EmployeeType) – Permanent, Contractor, Intern
//Create a JobTitle enum – Manager, Developer, Testor, Admin
//Create an Employee model (Id, FirstName, LastName, EmployeeType (enum type), JobTitle(enum type), HourlyRate, Address, Email, Phone)
//Create a HrStore class to manage employees
//Initialize Employee Object in HrStore class
//Develop methods to Add()/ Remove() / Get() / Update() employees
//Note:
//Use properties, constructor, Exception Handling and List

using System;
using System.Collections.Generic;

public enum EmployeeType
{
    Permanent,
    Contractor,
    Intern
}

public enum JobTitle
{
    Manager,
    Developer,
    Tester,
    Admin
}

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmployeeType EmployeeType { get; set; }
    public JobTitle JobTitle { get; set; }
    public decimal HourlyRate { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Employee(int id, string firstName, string lastName, EmployeeType employeeType, JobTitle jobTitle, decimal hourlyRate, string address, string email, string phone)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmployeeType = employeeType;
        JobTitle = jobTitle;
        HourlyRate = hourlyRate;
        Address = address;
        Email = email;
        Phone = phone;
    }

    public override string ToString()
    {
        return $"{Id}, {FirstName} {LastName}, {EmployeeType}, {JobTitle}, {HourlyRate}, {Address}, {Email}, {Phone}";
    }
}

public class HrStore
{
    private List<Employee> employees;

    public HrStore()
    {
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void RemoveEmployee(int id)
    {
        employees.RemoveAll(e => e.Id == id);
    }

    public Employee GetEmployee(int id)
    {
        return employees.Find(e => e.Id == id);
    }

    public void UpdateEmployee(Employee employee)
    {
        int index = employees.FindIndex(e => e.Id == employee.Id);
        if (index != -1)
        {
            employees[index] = employee;
        }
        else
        {
            throw new Exception("Employee not found.");
        }
    }

    public void PrintEmployees()
    {
        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee.ToString());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        HrStore hrStore = new HrStore();
        Employee employee1 = new Employee(1, "John", "Doe", EmployeeType.Permanent, JobTitle.Manager, 30.0M, "123 Main St", "johndoe@email.com", "555-555-5555");
        Employee employee2 = new Employee(2, "Jane", "Smith", EmployeeType.Contractor, JobTitle.Developer, 25.0M, "456 Elm St", "janesmith@email.com", "555-555-5556");
        hrStore.AddEmployee(employee1);
        hrStore.AddEmployee(employee2);
        hrStore.PrintEmployees();
        Console.WriteLine("Updating John's hourly rate.");
        Employee john = hrStore.GetEmployee(1);
        john.HourlyRate = 35.0M;
        hrStore.UpdateEmployee(john);
        hrStore.PrintEmployees();
        Console.WriteLine("Removing Jane from employees.");
        hrStore.RemoveEmployee(2);
        hrStore.PrintEmployees();
    }
}
