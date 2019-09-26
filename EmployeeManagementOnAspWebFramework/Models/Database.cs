using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementOnAspWebFramework.Models
{
    public class Database
    {
        public List<Employee> EmployeeList { set; get; }
        public List<Manager> ManagerList { set; get; }
        public Database()
        {
            EmployeeList = new List<Employee>();
            ManagerList = new List<Manager>();
        }
        public void AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
        }
        public void AddManager(Manager manager)
        {
            ManagerList.Add(manager);
            AddEmployee(manager);
        }
    }
    
}
