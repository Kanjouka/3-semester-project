using Scheduler.Model;

namespace Schedular.WebApi.DTO;

public class ProjectDTO
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Address? Address { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan TotalHours { get; set; }
}