using System.ComponentModel.DataAnnotations;

namespace Scheduler.WebApi.DTO
{
    public class HourSlipDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public byte[]? RowVersion { get; set; } = null;
        public int ProjectId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}