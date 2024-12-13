using EmployeeList.Database;
using EmployeeList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeList.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDb dbcontext;

        public EmployeeController(EmployeeDb dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeViewModel viewModel)
        {
            var employee = new Employee
            {
                EmployeeFName = viewModel.EmployeeFName,
                EmployeeLName = viewModel.EmployeeLName,
                Email = viewModel.Email,
                Age = viewModel.Age,
                EmployeePost = viewModel.EmployeePost,
                Salary = viewModel.Salary,
                Experience = viewModel.Experience
            };
            dbcontext.Employees.Add(employee);
            dbcontext.SaveChanges();
            return RedirectToAction("List", "Employee");
        }
        [HttpGet]
        public IActionResult List()
        {
            var employee = dbcontext.Employees.ToList();
            return View(employee);
        }
       [HttpGet]

        public IActionResult Edit(int id)
        {
            var employee = dbcontext.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee viewModel)
        {
            var employee = dbcontext.Employees.Find(viewModel.Id);
            if(employee != null)
            {
                employee.EmployeeFName = viewModel.EmployeeFName;
                employee.EmployeeLName = viewModel.EmployeeLName;
                employee.Email = viewModel.Email;
                employee.Age = viewModel.Age;
                employee.Experience = viewModel.Experience;
                employee.Salary = viewModel.Salary;
                employee.EmployeePost = viewModel.EmployeePost;
                dbcontext.SaveChanges();
            }
            return RedirectToAction("List", "Employee");
            
        }
        [HttpPost]
        public IActionResult Delete(Employee viewModel)
        {
            var employee = dbcontext.Employees.FirstOrDefault(x => x.Id == viewModel.Id);
            if (employee != null)
            {
                dbcontext.Employees.Remove(employee);
                dbcontext.SaveChanges();
            }
            return RedirectToAction("List", "Employee");
        }
       
    }
}
