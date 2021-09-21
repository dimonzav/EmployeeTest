using BusinessData.Interfaces;
using BusinessData.Models;
using MetinvestTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MetinvestTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employees
        [Route("list")]
        public IActionResult List()
        {
            return Json(_employeeService.GetEmployees());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] EmployeeModel model)
        {
            try
            {
                _employeeService.AddEmployee(model);
                return new JsonResult("Employee added!");
            }
            catch
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
