namespace Scheduler.ApiClient.Dto;

public class ProjectDto
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public AddressDto? Address { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan TotalHours { get; set; }
}