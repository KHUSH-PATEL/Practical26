using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class EmployeeQueryRepository : IEmployeeQueryRepository
    {
        private readonly AppDbContext _context;

        public EmployeeQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Where(employee => !employee.IsDeleted).ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int? id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == id && !employee.IsDeleted);
            if (employee != null)
            {
                _context.Entry(employee).State = EntityState.Detached;
            }
            return employee;
        }
    }
}
