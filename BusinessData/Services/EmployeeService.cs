using AutoMapper;
using BusinessData.Interfaces;
using BusinessData.Models;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Domain.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessData.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(
            IUnitOfWork<ApplicationDbContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = _unitOfWork.GetRepository<Employee>();
            _mapper = mapper;
        }

        public List<EmployeeModel> GetEmployees()
        {
            ICollection<Employee> employees = _employeeRepository.GetList();
            List<EmployeeModel> models = new List<EmployeeModel>();
            foreach (Employee employee in employees)
            {
                models.Add(_mapper.Map<EmployeeModel>(employee));
            }
            return models;
        }

        public void AddEmployee(EmployeeModel model)
        {
            try
            {
                // business logic
                if (model.IsStaffMember)
                {
                    int lastEmployeeNumber = _unitOfWork.Context.Employees.Max(i => i.Number);
                    model.Number = ++lastEmployeeNumber;
                }

                _employeeRepository.Add(_mapper.Map<Employee>(model));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
