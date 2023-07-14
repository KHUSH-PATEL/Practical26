using AutoMapper;
using DataAccessLayer.Dto;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;

namespace DataAccessLayer.CQRS
{
    public class EmployeeCommand : IEmployeeCommand
    {
        private readonly IEmployeeCommandRepository _employeeCommandRepository;
        private readonly IMapper _mapper;

        public EmployeeCommand(IEmployeeCommandRepository employeeCommandRepository, IMapper mapper)
        {
            _employeeCommandRepository = employeeCommandRepository;
            _mapper = mapper;
        }
        public async Task<Employee> DeleteEmployee(int id)
        {
            return await _employeeCommandRepository.DeleteEmployee(id);
        }

        public async Task<Employee> InsertEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return await _employeeCommandRepository.CreateEmployee(employee);
        }

        public async Task<int> UpdateEmployee(int id, UpdateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.Id = id;
            return await _employeeCommandRepository.UpdateEmployee(employee);
        }
    }
}
