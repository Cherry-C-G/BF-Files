using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Employee> employeeList = new List<Employee>
            {
                new Employee{ Id = 1, Name = "Judy", DeptNo = 1, Age = 22},
                new Employee{ Id = 2, Name = "Alen", DeptNo = 2, Age = 23},
                new Employee{ Id = 3, Name = "Lily", DeptNo = 1, Age = 22},
                new Employee{ Id = 4, Name = "Chris", DeptNo = 2, Age = 19},
                new Employee{ Id = 5, Name = "Ben", DeptNo = 1, Age = 20},
                new Employee{ Id = 6, Name = "Tom", DeptNo = 2, Age = 26},
                new Employee{ Id = 7, Name = "Dylan", DeptNo = 2, Age = 29},
                new Employee{ Id = 8, Name = "Zoey", DeptNo = 1, Age = 23},
            };

            List<Department> departmentList = new List<Department>
            {
                new Department {Id = 1, Name = "Human Resources"},
                new Department {Id = 2, Name = "Development"},
            };


            #region Join Example
            //Join Query
            var query = from e in employeeList
                                join d in departmentList on e.DeptNo equals d.Id // we need to use equals here, == is not allowed
                                select new EmplDeptInfo
                                {
                                    EmplId = e.Id,
                                    DeptName = d.Name,
                                    EmplName = e.Name,
                                };

            var method = employeeList.Join(departmentList, 
                                   e => e.DeptNo,  // specify the first selector
                                   d => d.Id,          // specify the second selector
                                   (e, d) => new EmplDeptInfo
                                   {
                                       EmplId = e.Id,
                                       DeptName = d.Name,
                                       EmplName = e.Name,
                                   });
                            
            foreach (var item in method)
            {
                //Console.WriteLine(item.EmplId + " " + item.EmplName + " " + item.DeptName);
            }
            #endregion
        }
    }
}
