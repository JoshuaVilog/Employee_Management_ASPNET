using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models.Services;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public EmployeeController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            //var employee = context.Employees.ToList();
            var employee = context.Employees.OrderByDescending(p => p.Id).ToList();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeDto);
            }

            //SAVE THE NEW EMPLOYEE
            Employee employee = new Employee()
            {
                Rfid = employeeDto.Rfid,
                Lastname = employeeDto.Lastname,
                Firstname = employeeDto.Firstname,
                Middlename = employeeDto.Middlename,
                Birthdate = employeeDto.Birthdate,
                Age = employeeDto.Age,
            };

            context.Employees.Add(employee);
            context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        public IActionResult Edit(int id)
        {
            var employee = context.Employees.Find(id);

            if(employee == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            var employeeDto = new EmployeeDto()
            {
                Rfid = employee.Rfid,
                Lastname = employee.Lastname,
                Firstname = employee.Firstname,
                Middlename = employee.Middlename,
                Birthdate = employee.Birthdate,
                Age = employee.Age,
            };

            ViewData["EmployeeId"] = employee.Id;

            return View(employeeDto);

        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeDto employeeDto)
        {
            var employee = context.Employees.Find(id);

            if(employee == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            if (!ModelState.IsValid)
            {
                ViewData["EmployeeID"] = employee.Id;

                return View(employeeDto);
            }

            //UPDATE THE EMPLOYEE
            employee.Rfid = employeeDto.Rfid;
            employee.Lastname = employeeDto.Lastname;
            employee.Firstname = employeeDto.Firstname;
            employee.Middlename = employeeDto.Middlename;
            employee.Birthdate = employeeDto.Birthdate;
            employee.Age = employeeDto.Age;

            context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }
    }
}
