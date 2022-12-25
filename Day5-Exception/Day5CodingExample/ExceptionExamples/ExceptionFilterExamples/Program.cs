using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExceptionFilterExamples
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //The Employee list
            List<Employee> empList = new List<Employee>() 
            { 
                new Employee(101, "Alex"),
                new Employee(102, "Bob")
            };
            // Target Employee
            Employee targetEmp = new Employee(103, "Naomi");

            try
            {
                FindEmployeeThrowCustomEx(empList, targetEmp);
                //FindEmployeeThrowBaseEx(empList, targetEmp);
            }
            catch (Exception ex) when (ex.Message.Contains("not found"))
            {
                Console.WriteLine("Not Found");
                Console.WriteLine(ex);
            }
            catch(Exception ex) when (ex.Message.Contains("404"))
            {
                Console.WriteLine("404");
                Console.WriteLine(ex.Message);
            }
        }
        //this method will throw user-defined method
        public static void FindEmployeeThrowCustomEx(List<Employee> empList, Employee targetEmp)
        {
            if (!empList.Contains(targetEmp))
            {
                throw new EmployeeNotFoundException($"Employee: {targetEmp.EmployeeName} is  not found!");    
            }
        }

        public static void FindEmployeeThrowBaseEx(List<Employee> empList, Employee targetEmp)
        {
            if (!empList.Contains(targetEmp))
            {
                throw new Exception($"Employee: {targetEmp.EmployeeName} is  404!");
            }
        }

    }
}
