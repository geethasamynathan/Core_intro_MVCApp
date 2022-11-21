using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp1.Models;
namespace DemoApp1.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;
        }
        public string  Index()
        {
            var emp = _employeeRepository.GetEmployee(201);
            string empdetails = emp.Id + " \t " + emp.Name + "\t" + emp.Department + "\t" + emp.Email;
            return empdetails;
        }
    }
}
