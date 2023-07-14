using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class EmployeeCommandRepository : IEmployeeCommandRepository
    {
        private readonly AppDbContext _context;

        public EmployeeCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employeeData = await _context.Employees.FindAsync(id);
            if (employeeData != null)
            {
                employeeData.IsDeleted = true;
                _context.Employees.Update(employeeData);
                await _context.SaveChangesAsync();
                return employeeData;
            }
            return null;
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }
    }
}
