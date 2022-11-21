using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp1.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
                { 
                new Employee(){Id=201,Name="Prathyush",Department="Admin",Email="Prathyush@hexaware.com"},
                  new Employee(){Id=202,Name="Vasavi",Department="HR",Email="Vasavih@hexaware.com"},
                    new Employee(){Id=203,Name="Shivani",Department="IT",Email="Shivani@hexaware.com"},
                      new Employee(){Id=204,Name="Gouri",Department="Sales",Email="Gouri@hexaware.com"},

            };

        }
        public Employee GetEmployee(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(emp => emp.Id == id);
            return employee;
        }
    }
}
