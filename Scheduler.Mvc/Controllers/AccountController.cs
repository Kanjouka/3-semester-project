using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;
using Scheduler.Mvc.Models;
using System.Security.Claims;

namespace Scheduler.Mvc.Controllers;

public class AccountController : Controller
{
    private IEmployeeDao<EmployeeDto> _employeeDao;

    public AccountController(IEmployeeDao<EmployeeDto> employeeDao)
    {
        _employeeDao = employeeDao;
    }
    // GET: AccountController
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] EmployeeView loginInfo, [FromQuery] string returnUrl)
    {
        try
        {
            var employee = await _employeeDao.LoginAsync(loginInfo.Email, loginInfo.Password);
            if (employee == null)
            {
                return View();
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId.ToString()),
                    new Claim(ClaimTypes.Email, employee.Email),
                    new Claim(ClaimTypes.Role, employee.Role),
                    new Claim(ClaimTypes.Name, $"{employee.FirstName} {employee.LastName}")
                };

            await SignInUsingClaims(claims);
            TempData["Message"] = $"You are logged in as {employee.FirstName} {employee.LastName}";
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            return Redirect("~/dashboard");
        }
        catch (Exception)
        {

            return View();
        }
    }
    private async Task SignInUsingClaims(List<Claim> claims)
    {
        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
    }
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        TempData["Message"] = "You are now logged out.";
        return RedirectToAction("Index", "");
    }

    public async Task<IActionResult> AccessDenied()
    {
        return View();
    }
}