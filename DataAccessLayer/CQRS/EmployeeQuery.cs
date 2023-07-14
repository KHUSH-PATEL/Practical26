using AutoMapper;
using DataAccessLayer.Dto;
using DataAccessLayer.Interface;

namespace DataAccessLayer.CQRS
{
    public class EmployeeQuery : IEmployeeQuery
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IMapper _mapper;

        public EmployeeQuery(IEmployeeQueryRepository employeeQueryRepository, IMapper mapper)
        {
            _employeeQueryRepository = employeeQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var employeeList = await _employeeQueryRepository.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employeeList);
        }

        public async Task<EmployeeDto> GetById(int id)
        {
            var employee = await _employeeQueryRepository.GetEmployeeById(id);            
            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
