using BusinessData.Models;
using System.Collections.Generic;

namespace BusinessData.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetEmployees();

        void AddEmployee(EmployeeModel model);
    }
}
