using DataAccessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeQuery
    {
        Task<EmployeeDto> GetById(int id);
        Task<IEnumerable<EmployeeDto>> GetAll();
    }
}
