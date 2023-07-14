using DataAccessLayer.Dto;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeCommandRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
