using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;
using Scheduler.Model;
using Scheduler.Mvc.Models;
using System.Security.Claims;

namespace Scheduler.Mvc.Controllers;

[Authorize]
public class DashboardController : Controller
{
    private IHourSlipDaoAsync<HourSlipDto> _hourSlipDao;
    private IEmployeeDao<EmployeeDto> _employeeDao;

    public DashboardController(IHourSlipDaoAsync<HourSlipDto> hourSlipDAO, IEmployeeDao<EmployeeDto> employeeDao)
    {
        _hourSlipDao = hourSlipDAO;
        _employeeDao = employeeDao;
    }

    // GET: DashboardController
    public async Task<IActionResult> Index()
    {
        try
        {
            if (User.IsInRole("Manager"))
            {
                return await ViewDashboardAsManager();
            }
            else
            {
                return await ViewDashboardAsEmployee();
            }
        }
        catch (Exception ex)
        {
            return View("ApiError");
        }
    }

    private async Task<IActionResult> ViewDashboardAsEmployee()
    {
        DashboardViewModel dashboardViewModel = new DashboardViewModel();
        IEnumerable<HourSlipDto> loggedInEmployeeHourSlips = await _hourSlipDao.GetAllHourSlipsFromEmployeeAsync(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        dashboardViewModel.HourSlips = loggedInEmployeeHourSlips.Select(hourslip => Mapper.DtoHourSlipToHourSlip(hourslip));
        return View(dashboardViewModel);
    }

    private async Task<IActionResult> ViewDashboardAsManager()
    {
        DashboardViewModel dashboardViewModel = new DashboardViewModel();
        var hourSlipsDTOs = await _hourSlipDao.GetAllUnapprovedHourSlipsAsync();
        var employeesDTOs = await _employeeDao.GetAllAsync();

        dashboardViewModel.HourSlips = hourSlipsDTOs.Select(hourslipDTO =>
        {
            var HourSlipView = Mapper.DtoHourSlipToHourSlip(hourslipDTO);
            var employeeDTOWithMatchingID = employeesDTOs.FirstOrDefault(employeeDTO => employeeDTO.EmployeeId == HourSlipView.EmployeeId);
            HourSlipView.Employee = Mapper.DtoEmployeeToEmployee(employeeDTOWithMatchingID);
            return HourSlipView;
        });

        return View(dashboardViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateHourSlip(DashboardViewModel dashboardViewModel)
    {
        HourSlipView hourSlip = dashboardViewModel.HourSlip;
        try
        {
            if (hourSlip.StartTime > hourSlip.EndTime)
            {
                TempData["Error"] = "Endtime can not be before starttime";
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "An error occurred while creating the hour slip. try again";
                return RedirectToAction("Index");
            }
            int employeeId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            hourSlip.EmployeeId = employeeId;
            await _hourSlipDao.AddAsync(Mapper.HourSlipToDtoHourSlip(hourSlip));
            TempData["Success"] = "Hour slip created successfully.";
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            TempData["Error"] = "An error occurred while creating the hour slip. try again";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ApproveHourSlip(DashboardViewModel dashboardViewModel)
    {
        HourSlipView hourSlip = dashboardViewModel.HourSlip;
        try
        {
            bool approved = await _hourSlipDao.ApproveHourSlip(Mapper.HourSlipToDtoHourSlip(hourSlip));
            if (approved)
            {
                TempData["Success"] = "Hour slip was successfully approved.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = $"An error occured. Hour slip was not approved. try again";
                return RedirectToAction("Index");
            }
        }
        catch (Exception)
        {
            TempData["Error"] = $"An error occured. Hour slip was not approved. try again";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateHourSlip(DashboardViewModel dashboardViewModel)
    {
        HourSlipView hourSlipView = dashboardViewModel.HourSlip;
        try
        {
            if (hourSlipView.StartTime > hourSlipView.EndTime)
            {
                TempData["Error"] = "Endtime can not be before starttime";
                return RedirectToAction("Index");
            }
            bool isSuccessful = await _hourSlipDao.UpdateAsync(Mapper.HourSlipToDtoHourSlip(hourSlipView));
            if (!isSuccessful)
            {
                TempData["Error"] = $"An error occured. Hour slip was not updated. try again";
                return RedirectToAction("Index");
            }

            TempData["Success"] = "Hour slip was successfully Updated.";
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            TempData["Error"] = $"An error occured. Hour slip was not updated. try again";
            return RedirectToAction("Index");
        }
    }
}