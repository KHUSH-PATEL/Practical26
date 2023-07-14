using DataAccessLayer.Dto;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeCommand
    {
        Task<Employee> InsertEmployee(CreateEmployeeDto employee);
        Task<int> UpdateEmployee(int id, UpdateEmployeeDto employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
