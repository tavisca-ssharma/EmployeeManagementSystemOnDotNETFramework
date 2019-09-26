using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementOnAspWebFramework.Controllers
{
    public class ValuesController : ApiController
    {
        Models.Database employeeDatabase;
        bool IsConnectedToDatabase = false;
        public string Get()
        {
            return "Welcome To Web API";
        }
        //GET manager/id
        public IEnumerable<string> Get(string requestedItem, string id)
        {
            if (!IsConnectedToDatabase)
                ConnectToDatabase();
            if (requestedItem.ToLower() == "manager")
                return GetAllEmployeeWorkingWithManager(id);
            return new List<string>();
        }

        //GET managers or employees
        [HttpGet]
        public IEnumerable<string> Get(string requestedItem)
        {
            if (!IsConnectedToDatabase)
                ConnectToDatabase();
            if (requestedItem.ToLower() == "employees")
                return GetAllEmployeeDetails();
            if (requestedItem.ToLower() == "managers")
                return GetAllManagerDetails();
            return new List<string>();
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public void ConnectToDatabase()
        {
            employeeDatabase = new Models.Database();
            Models.Employee E1 = new Models.Employee("E1", "Ram", 90000, 23, "Flights", "SDE2");
            employeeDatabase.AddEmployee(E1);
            Models.Employee E2 = new Models.Employee("E2", "Manish", 100000, 25, "CHAI", "SDE1");
            employeeDatabase.AddEmployee(E2);
            Models.Employee E3 = new Models.Employee("E3", "Shivang", 15000, 22, "UI", "Trainee");
            employeeDatabase.AddEmployee(E3);
            Models.Employee E4 = new Models.Employee("E4", "Aditi", 90000, 28, "CAPI", "SDE3");
            employeeDatabase.AddEmployee(E4);
            Models.Employee E5 = new Models.Employee("E5", "Ravi", 90000, 29, "CHAI", "BA");
            employeeDatabase.AddEmployee(E5);
            Models.Employee E6 = new Models.Employee("E6", "Krishna", 80000, 23, "CAPI", "BA");
            employeeDatabase.AddEmployee(E6);
            Models.Employee E7 = new Models.Employee("E7", "Kapil", 70000, 25, "UI", "SDE1");
            employeeDatabase.AddEmployee(E7);

            List<Models.Employee> L1 = new List<Models.Employee>();
            L1.Add(E1); L1.Add(E2); L1.Add(E3); L1.Add(E4);
            Models.Manager M1 = new Models.Manager("M1", "Ramesh", 120000, 23, "Flights", "IM", L1);
            employeeDatabase.AddManager(M1);

            List<Models.Employee> L2 = new List<Models.Employee>();
            L2.Add(E5); L2.Add(E6);
            Models.Manager M2 = new Models.Manager("M2", "Rakesh", 130000, 23, "Flights", "IM", L2);
            employeeDatabase.AddManager(M2);

            List<Models.Employee> L3 = new List<Models.Employee>();
            L3.Add(E7);
            Models.Manager M3 = new Models.Manager("M3", "Suresh", 150000, 23, "CHAI", "IM", L3);
            employeeDatabase.AddManager(M3);
            IsConnectedToDatabase = true;
        }
        protected List<string> GetAllEmployeeDetails()
        {
            List<string> employeeDetails = new List<string>();
            foreach (var employee in employeeDatabase.EmployeeList)
                employeeDetails.Add(employee.GetEmployeeDetails());
            return employeeDetails;
        }
        protected List<string> GetAllManagerDetails()
        {
            List<string> managerDetails = new List<string>();
            foreach (var manager in employeeDatabase.ManagerList)
                managerDetails.Add(manager.GetEmployeeDetails());
            return managerDetails;
        }
        protected List<string> GetAllEmployeeWorkingWithManager(string managerId)
        {
            List<string> employeeDetails = new List<string>();
            foreach (var manager in employeeDatabase.ManagerList)
            {
                if (manager.Id == managerId)
                {
                    foreach (Models.Employee employee in manager.Employees)
                        employeeDetails.Add(employee.GetEmployeeDetails());
                }
            }
            return employeeDetails;
        }
    }
}
