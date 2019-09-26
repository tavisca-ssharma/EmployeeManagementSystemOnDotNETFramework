using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementOnAspWebFramework.Models
{
    public class Manager : Employee
    {
        public List<Employee> Employees;
        public Manager(string Id, string Name, long Salary, int Age, string Department, string Designation, List<Employee> employees) : base(Id, Name, Salary, Age, Department, Designation)
        {
            Employees = employees;
        }
    }
}