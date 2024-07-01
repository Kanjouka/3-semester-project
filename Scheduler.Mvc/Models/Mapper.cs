using Microsoft.Build.Evaluation;
using Scheduler.ApiClient.Dto;
using Scheduler.Model;

namespace Scheduler.Mvc.Models;

public static class Mapper
{
    public static HourSlipView DtoHourSlipToHourSlip(HourSlipDto hourSlipDto)
    {
        var NewHourSlip = new HourSlipView();
        NewHourSlip.Id = hourSlipDto.Id;
        NewHourSlip.EmployeeId = hourSlipDto.EmployeeId;
        NewHourSlip.Date = hourSlipDto.Date;
        NewHourSlip.IsApproved = hourSlipDto.IsApproved;
        NewHourSlip.StartTime = hourSlipDto.StartTime;
        NewHourSlip.EndTime = hourSlipDto.EndTime;
        NewHourSlip.ProjectId = hourSlipDto.ProjectId;
        NewHourSlip.Id = hourSlipDto.Id;
        NewHourSlip.RowVersion = hourSlipDto.RowVersion;

        return NewHourSlip;
    }

    public static HourSlipDto HourSlipToDtoHourSlip(HourSlipView hourSlip)
    {
        var NewHourSlipDto = new HourSlipDto();
        NewHourSlipDto.EmployeeId = hourSlip.EmployeeId;
        NewHourSlipDto.Date = hourSlip.Date;
        NewHourSlipDto.IsApproved = hourSlip.IsApproved;
        NewHourSlipDto.StartTime = hourSlip.StartTime;
        NewHourSlipDto.EndTime = hourSlip.EndTime;
        NewHourSlipDto.ProjectId = hourSlip.ProjectId;
        NewHourSlipDto.Id = hourSlip.Id;
        NewHourSlipDto.RowVersion = hourSlip.RowVersion;
        return NewHourSlipDto;
    }

    public static EmployeeView DtoEmployeeToEmployee(EmployeeDto employeeDto)
    {
        var NewEmployee = new EmployeeView();
        NewEmployee.EmployeeId = employeeDto.EmployeeId;
        NewEmployee.FirstName = employeeDto.FirstName;
        NewEmployee.LastName = employeeDto.LastName;
        NewEmployee.Email = employeeDto.Email;
        NewEmployee.Password = employeeDto.Password;
        NewEmployee.Role = employeeDto.Role;
        NewEmployee.PhoneNumber = employeeDto.PhoneNumber;
        return NewEmployee;
    }

    public static EmployeeDto EmployeeToDtoEmployee(EmployeeView employee)
    {
        var NewEmployeeDto = new EmployeeDto();
        NewEmployeeDto.EmployeeId = employee.EmployeeId;
        NewEmployeeDto.FirstName = employee.FirstName;
        NewEmployeeDto.LastName = employee.LastName;
        NewEmployeeDto.Email = employee.Email;
        NewEmployeeDto.Password = employee.Password;
        NewEmployeeDto.Role = employee.Role;
        NewEmployeeDto.PhoneNumber = employee.PhoneNumber;
        return NewEmployeeDto;
    }

    public static ProjectView DtoProjectToProject(ProjectDto projectDto)
    {
        var newProject = new ProjectView();
        newProject.ProjectId = projectDto.ProjectId;
        newProject.Name = projectDto.Name;
        newProject.Description = projectDto.Description;
        newProject.StartDate = projectDto.StartDate;
        newProject.EndDate = projectDto.EndDate;
        newProject.TotalHours = projectDto.TotalHours;
        return newProject;
    }

    public static ProjectDto ProjectToDtoProject(ProjectView project)
    {
        var newProjectDto = new ProjectDto();
        newProjectDto.ProjectId = project.ProjectId;
        newProjectDto.Name = project.Name;
        newProjectDto.Description = project.Description;
        newProjectDto.StartDate = project.StartDate;
        newProjectDto.EndDate = project.EndDate;
        newProjectDto.TotalHours = project.TotalHours;
        return newProjectDto;
    }
}