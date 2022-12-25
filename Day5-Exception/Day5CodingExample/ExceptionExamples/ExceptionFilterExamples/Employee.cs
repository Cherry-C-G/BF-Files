using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionFilterExamples
{
    internal class Employee
    {
        //properties
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        //constructors
        public Employee() { }
        public Employee(int employeeID, string employeeName)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
        }
    }

    //user-defined Exception
    internal class EmployeeNotFoundException : Exception
    {
        //constructors
        public EmployeeNotFoundException():base() { }
        public EmployeeNotFoundException(string message):base(message) { }

    }
}
