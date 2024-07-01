using Microsoft.AspNetCore.Mvc;
using Scheduler.Interfaces;
using Scheduler.Model;
using Scheduler.WebApi.DTO;

namespace Scheduler.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountsController : Controller
{
    private IEmployeeDao<Employee> _EmployeeDao;

    public AccountsController(IEmployeeDao<Employee> employeeDao) => _EmployeeDao = employeeDao;

    // POST api/<AccountsController>
    [HttpPost]
    public async Task<ActionResult<EmployeeDTO>> LoginAsync([FromBody] LoginDto loginDto)
    {
        var employee = await _EmployeeDao.LoginAsync(loginDto.Email, loginDto.Password);
        if (employee == null)
        {
            return Unauthorized();
        }
        var employeeDto = Mapper.EmployeeToEmployeeDTO(employee);
        if (employeeDto == null)
        {
            return Unauthorized();
        }
        return Ok(employeeDto);
    }
}