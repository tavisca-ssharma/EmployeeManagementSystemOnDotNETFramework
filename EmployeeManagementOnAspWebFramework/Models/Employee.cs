using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementOnAspWebFramework.Models
{
    public class Employee
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public long Salary { set; get; }
        public int Age { set; get; }
        public string Department { set; get; }
        public string Designation { set; get; }

        public Employee(string Id, string Name, long Salary, int Age, string Department, string Designation)
        {
            this.Id = Id;
            this.Name = Name;
            this.Salary = Salary;
            this.Age = Age;
            this.Department = Department;
            this.Designation = Designation;

        }
        public string GetEmployeeDetails()
        {
            return $"Id : {Id}, Name : {Name}, Salary : {Salary}, Age : {Age}, Department : {Department}, Designation : {Designation} ";
        }
    }
}