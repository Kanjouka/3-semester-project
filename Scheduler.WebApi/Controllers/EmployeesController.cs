using Microsoft.AspNetCore.Mvc;
using Scheduler.Interfaces;
using Scheduler.Model;
using Scheduler.WebApi.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scheduler.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeDao<Employee> _EmployeeDao;

        public EmployeesController(IEmployeeDao<Employee> employeeDao) => _EmployeeDao = employeeDao;

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployeeAsync()
        {
            IEnumerable<Employee> employees = await _EmployeeDao.GetAllAsync();
            IEnumerable<EmployeeDTO> employeeDTOs = employees.Select(employees => Mapper.EmployeeToEmployeeDTO(employees)).ToList();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeAsync(int id)
        {
            Employee employee = await _EmployeeDao.GetByIdAsync(id);
            EmployeeDTO employeeDTO = Mapper.EmployeeToEmployeeDTO(employee);
            if (employeeDTO == null)
            {
                return NotFound();
            }
            return Ok(employeeDTO);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> AddEmployeAsync(EmployeeDTO employeeDTO)
        {
            Employee employee = Mapper.EmployeeDTOToEmployee(employeeDTO);
            int id = await _EmployeeDao.AddAsync(employee);
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(id);
        }

        // PUT api/<EmployeeController>
        [HttpPut]
        public async Task<ActionResult> UpdateEmployeeAsync([FromBody] EmployeeDTO employeeDTO)
        {
            Employee employee = Mapper.EmployeeDTOToEmployee(employeeDTO);
            bool isSucces = await _EmployeeDao.UpdateAsync(employee);
            if (!isSucces)
            {
                return BadRequest();
            }
            return Ok(isSucces);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int id)
        {
            bool isSucces = await _EmployeeDao.DeleteAsync(id);
            if (!isSucces)
            {
                return BadRequest();
            }
            return Ok(isSucces);
        }
    }
}