using DataAccessLayer.Model;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeQueryRepository
    {
        Task<Employee?> GetEmployeeById(int? id);
        Task<IEnumerable<Employee>> GetAllEmployees();
    }
}
