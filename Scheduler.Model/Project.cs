using System.ComponentModel.DataAnnotations;

namespace Scheduler.Model
{
    public class Project
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
        public Address? Address { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public TimeSpan TotalHours { get; set; }

        public int TotalMinutesInt { get; set; }
    }
}