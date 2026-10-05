using LeaveManagementSystem.DTOs.Employee;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if(employee==null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id,UpdateEmployeeDto dto)
        {
            var employee = await _employeeService.UpdateAsync(id,dto);
            if(employee==null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateEmployeeDto dto)
        {
            var employee = await _employeeService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = employee.EmployeeId },
                employee);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var deleted = await _employeeService.DeleteAsync(id);
            if(!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
