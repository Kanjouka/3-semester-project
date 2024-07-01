using System.ComponentModel.DataAnnotations;

namespace Scheduler.Mvc.Models;

public class ProjectView
{
    [Key]
    public int ProjectId { get; set; }

    [Required]
    [MaxLength(60)]
    public string Name { get; set; }

    [Required]
    [MaxLength(2000)]
    public string? Description { get; set; }

    [Required]
    public AddressView? Address { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public TimeSpan TotalHours { get; set; }
}