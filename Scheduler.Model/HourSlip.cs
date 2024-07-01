using System.ComponentModel.DataAnnotations;

namespace Scheduler.Model;

public class HourSlip
{
    public int Id { get; set; }

    public byte[]? RowVersion { get; set; } = null;

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public bool IsApproved { get; set; } = false;

    [Required]
    public int ProjectId { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public HourSlip(int employeeId, DateTime date, int projectId, DateTime startTime, DateTime endTime)
    {
        EmployeeId = employeeId;
        Date = date;
        ProjectId = projectId;
        StartTime = startTime;
        EndTime = endTime;
    }

    public HourSlip()
    {
    }
}