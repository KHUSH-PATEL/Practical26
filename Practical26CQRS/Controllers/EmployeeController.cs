using AutoMapper;
using DataAccessLayer.Dto;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practical26CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeCommand _employeeCommands;
        private readonly IEmployeeQuery _employeeQueries;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeCommand employeeCommands, IEmployeeQuery employeeQueries, IMapper mapper)
        {
            _employeeCommands = employeeCommands;
            _employeeQueries = employeeQueries;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetStudents()
        {
            var employees = await _employeeQueries.GetAll();           
            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeQueries.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployee)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList());
                return UnprocessableEntity(ModelState);
            }
            var employee = await _employeeCommands.InsertEmployee(createEmployee);
            return Ok(employee);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int id, UpdateEmployeeDto updateEmployee)
        {
            var employeeEntity = await _employeeQueries.GetById(id);            
            if (employeeEntity is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList());
                return UnprocessableEntity(ModelState);
            }
            var employee = await _employeeCommands.UpdateEmployee(id, updateEmployee);
            return Ok(employee);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployee(int id)
        {
            var employeeEntity = await _employeeQueries.GetById(id);
            if (employeeEntity is null)
            {
                return NotFound();
            }
            var employee = await _employeeCommands.DeleteEmployee(id);
            return Ok(employee);
        }
    }
}
