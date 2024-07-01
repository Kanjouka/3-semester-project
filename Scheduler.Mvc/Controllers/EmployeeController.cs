using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;
using Scheduler.Mvc.Models;

namespace Scheduler.Mvc.Controllers;

[Authorize(Roles = "Manager")]
public class EmployeeController : Controller
{
    private IEmployeeDao<EmployeeDto> _employeeDao;

    public EmployeeController(IEmployeeDao<EmployeeDto> employeeDao)
    {
        _employeeDao = employeeDao;
    }

    // GET: EmployeeController
    public async Task<ActionResult> Index()
    {
        var employeeDTOS = await _employeeDao.GetAllAsync();
        var employees = employeeDTOS.Select(employee => Mapper.DtoEmployeeToEmployee(employee));

        if (employees == null)
        {
            return NotFound();
        }
        return View(employees);
    }

    // For future version
    public async Task<ActionResult> Details(int id)
    {
        var employee = await _employeeDao.GetByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    // For future version
    public ActionResult Create()
    {
        return View();
    }

    // For future version
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(EmployeeView employee)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (employee == null)
            {
                return View();
            }
            var employeeDto = Mapper.EmployeeToDtoEmployee(employee);
            await _employeeDao.AddAsync(employeeDto);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // For future version
    public async Task<ActionResult> Edit(int id)
    {
        var employeeDto = await _employeeDao.GetByIdAsync(id);
        var employeeToEdit = Mapper.DtoEmployeeToEmployee(employeeDto);
        return View(employeeToEdit);
    }

    // For future version
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, EmployeeView employee)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            if (employee == null)
            {
                return View(employee);
            }
            var employeeDto = Mapper.EmployeeToDtoEmployee(employee);
            await _employeeDao.UpdateAsync(employeeDto);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // For future version
    public async Task<ActionResult> Delete(int id)
    {
        var employeeToDeleteDto = await _employeeDao.GetByIdAsync(id);
        return View(Mapper.DtoEmployeeToEmployee(employeeToDeleteDto));
    }

    // For future version
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, EmployeeView employee)
    {
        try
        {
            await _employeeDao.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}