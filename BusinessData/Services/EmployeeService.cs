using AutoMapper;
using BusinessData.Interfaces;
using BusinessData.Models;
using DataAccess.UnitOfWork;
using Domain.Entities;
using System.Collections.Generic;

namespace BusinessData.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<EmployeeModel> GetEmployees()
        {
            ICollection<Employee> employees = _unitOfWork.GetRepository<Employee>().GetList();
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
                var modell = _mapper.Map<Employee>(model);

                _unitOfWork.GetRepository<Employee>()
                    .Add(_mapper.Map<Employee>(model));
            }
            catch
            {
                throw;
            }
        }
    }
}
