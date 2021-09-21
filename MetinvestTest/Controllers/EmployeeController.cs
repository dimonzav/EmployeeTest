using AutoMapper;
using DataAccess.UnitOfWork;
using Domain.Entities;
using MetinvestTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MetinvestTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            ICollection<Employee> employees = _unitOfWork.GetRepository<Employee>().GetList();
            List<EmployeeModel> models = new List<EmployeeModel>();
            foreach (Employee employee in employees)
            {
                models.Add(_mapper.Map<EmployeeModel>(employee));
            }
            return Json(models);
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
                var modell =_mapper.Map<Employee>(model);

                _unitOfWork.GetRepository<Employee>()
                    .Add(_mapper.Map<Employee>(model));
                return new JsonResult("Added!");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
