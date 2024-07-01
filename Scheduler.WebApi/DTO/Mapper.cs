using Schedular.WebApi.DTO;
using Scheduler.Dal;
using Scheduler.Model;

namespace Scheduler.WebApi.DTO
{
    public class Mapper
    {
        public static HourSlip DtoHourSlipToHourSlip(HourSlipDTO hourSlipDto)
        {
            var NewHourSlip = new HourSlip();
            NewHourSlip.Id = hourSlipDto.Id;
            NewHourSlip.EmployeeId = hourSlipDto.EmployeeId;
            NewHourSlip.Date = hourSlipDto.Date;
            NewHourSlip.IsApproved = hourSlipDto.IsApproved;
            NewHourSlip.StartTime = hourSlipDto.StartTime;
            NewHourSlip.EndTime = hourSlipDto.EndTime;
            NewHourSlip.RowVersion = hourSlipDto.RowVersion;
            NewHourSlip.ProjectId = hourSlipDto.ProjectId;

            return NewHourSlip;
        }

        public static HourSlipDTO HourSlipToDtoHourSlip(HourSlip hourSlip)
        {
            var NewHourSlipDto = new HourSlipDTO();
            NewHourSlipDto.Id = hourSlip.Id;
            NewHourSlipDto.EmployeeId = hourSlip.EmployeeId;
            NewHourSlipDto.Date = hourSlip.Date;
            NewHourSlipDto.IsApproved = hourSlip.IsApproved;
            NewHourSlipDto.StartTime = hourSlip.StartTime;
            NewHourSlipDto.EndTime = hourSlip.EndTime;
            NewHourSlipDto.RowVersion = hourSlip.RowVersion;
            NewHourSlipDto.ProjectId = hourSlip.ProjectId;
            return NewHourSlipDto;
        }

        public static EmployeeDTO EmployeeToEmployeeDTO(Employee employee)
        {
            EmployeeDTO employeeDto = new EmployeeDTO();
            employeeDto.EmployeeId = employee.EmployeeId;
            employeeDto.FirstName = employee.FirstName;
            employeeDto.LastName = employee.LastName;
            employeeDto.Role = employee.Role;
            employeeDto.Email = employee.Email;
            employeeDto.PhoneNumber = employee.PhoneNumber;
            if (employee.Address != null)
            {
                employeeDto.Address = employee.Address;
            }

            return employeeDto;
        }

        public static Employee EmployeeDTOToEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee();
            employee.EmployeeId = employeeDTO.EmployeeId;
            employee.FirstName = employeeDTO.FirstName;
            employee.LastName = employeeDTO.LastName;
            employee.Email = employeeDTO.Email;
            employee.PhoneNumber = employeeDTO.PhoneNumber;
            employee.Password = employeeDTO.Password;
            employee.Role = employeeDTO.Role;
            if (employeeDTO.Address != null)
            {
                employee.Address = employeeDTO.Address;
            }

            return employee;
        }

        public static ProjectDTO ProjectToProjectDTO(Project project)
        {
            ProjectDTO projectDTO = new ProjectDTO();
            projectDTO.ProjectId = project.ProjectId;
            projectDTO.Name = project.Name;
            projectDTO.Description = project.Description;
            projectDTO.Address = project.Address;
            projectDTO.StartDate = project.StartDate;
            projectDTO.EndDate = project.EndDate;
            projectDTO.TotalHours = project.TotalHours;
            return projectDTO;
        }

        public static Project ProjectDTOToProject(ProjectDTO projectDTO)
        {
            Project project = new Project();
            project.ProjectId = projectDTO.ProjectId;
            project.Name = projectDTO.Name;
            project.Description = projectDTO.Description;
            project.Address = projectDTO.Address;
            project.StartDate = projectDTO.StartDate;
            project.EndDate = projectDTO.EndDate;
            project.TotalHours = projectDTO.TotalHours;
            return project;
        }
    }
}