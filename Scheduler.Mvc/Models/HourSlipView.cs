using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Mvc.Models;

public class HourSlipView
{
    public int Id { get; set; }

    public byte[]? RowVersion { get; set; }

    public int EmployeeId { get; set; }

    public EmployeeView? Employee { get; set; }

    public DateTime Date { get; set; }
    public bool IsApproved { get; set; } = false;

    public int ProjectId { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public HourSlipView(int employeeId, DateTime date, int projectId, DateTime startTime, DateTime endTime)
    {
        EmployeeId = employeeId;
        Date = date;
        ProjectId = projectId;
        StartTime = startTime;
        EndTime = endTime;
    }

    public HourSlipView()
    {
    }
}