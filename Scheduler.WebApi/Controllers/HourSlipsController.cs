using Microsoft.AspNetCore.Mvc;
using Scheduler.Interfaces;
using Scheduler.Model;
using Scheduler.WebApi.DTO;

namespace Scheduler.WebApi.Controllers;

/// <summary>
/// Handles the communication with DAL.
/// Returns requests using DTO.
/// See DTO documentation for further information on returnvalues.
/// </summary>
[Route("[controller]")]
[ApiController]
public class HourSlipsController : ControllerBase
{
    private IHourSlipDaoAsync<HourSlip> _hourSlipDao;

    public HourSlipsController(IHourSlipDaoAsync<HourSlip> hourSlipDao) => _hourSlipDao = hourSlipDao;

    // GET: api/<HourSlipsController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HourSlipDTO>>> GetAllHourslpisAsync()
    {
        IEnumerable<HourSlip> hourSlips = await _hourSlipDao.GetAllAsync();
        IEnumerable<HourSlipDTO> hourSlipDto = hourSlips.Select(hourslip => Mapper.HourSlipToDtoHourSlip(hourslip));
        if (hourSlips == null)
        {
            return NotFound();
        }
        return Ok(hourSlips);
    }

    // GET api/<HourSlipsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HourSlipDTO>> GetHourslipAsync(int id)
    {
        HourSlip hourSlip = await _hourSlipDao.GetByIdAsync(id);
        HourSlipDTO hourSlipDTO = Mapper.HourSlipToDtoHourSlip(hourSlip);
        if (hourSlipDTO == null)
        {
            return BadRequest();
        }
        return Ok(hourSlipDTO);
    }

    // POST api/<HourSlipsController>
    [HttpPost]
    public async Task<ActionResult<HourSlipDTO>> AddHourslipAsync([FromBody] HourSlipDTO hourSlipDTO)
    {
        int id = await _hourSlipDao.AddAsync(Mapper.DtoHourSlipToHourSlip(hourSlipDTO));
        if (id == 0)
        {
            return BadRequest();
        }
        return Ok(id);
    }

    // PUT api/<HourSlipsController>/
    [HttpPut]
    public async Task<ActionResult<HourSlipDTO>> UpdateHourslipAsync([FromBody] HourSlipDTO hourSlipDTO)
    {
        bool isSucces = false;
        HourSlip NewHourSlip = Mapper.DtoHourSlipToHourSlip(hourSlipDTO);
        HourSlip OldhourSlip = await _hourSlipDao.GetByIdAsync(hourSlipDTO.Id);
        if (NewHourSlip.StartTime != OldhourSlip.StartTime || NewHourSlip.EndTime != OldhourSlip.EndTime)
        {
            isSucces = await _hourSlipDao.UpdateAsync(NewHourSlip);
        }
        if (!isSucces)
        {
            return BadRequest();
        }
        return Ok(isSucces);
    }

    // DELETE api/<HourSlipsController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<HourSlipDTO>> DeleteHourslipAsync(int id)
    {
        bool isSucces = await _hourSlipDao.DeleteAsync(id);
        if (!isSucces)
        {
            return BadRequest();
        }
        return Ok(isSucces);
    }

    [HttpGet("employees/{employeeId}")]
    public async Task<ActionResult<IEnumerable<HourSlipDTO>>> GetAllHourSlipsFromEmployeeAsync(int employeeId)
    {
        var hourSlips = await _hourSlipDao.GetAllHourSlipsFromEmployeeAsync(employeeId);
        return Ok(hourSlips);
    }

    [HttpGet]
    [Route("unapproved")]
    public async Task<ActionResult<IEnumerable<HourSlipDTO>>> GetAllUnapprovedHourSlipsAsync()
    {
        var hourSlips = await _hourSlipDao.GetAllUnapprovedHourSlipsAsync();
        return Ok(hourSlips);
    }

    [HttpPut]
    [Route("approve")]
    public async Task<ActionResult<IEnumerable<HourSlipDTO>>> ApproveHourSlipAsync(HourSlipDTO hourSlipDto)
    {
        var hourSlips = await _hourSlipDao.ApproveHourSlip(Mapper.DtoHourSlipToHourSlip(hourSlipDto));
        return Ok(hourSlips);
    }
}