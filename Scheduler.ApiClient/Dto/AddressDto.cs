using System.ComponentModel.DataAnnotations;

namespace Scheduler.ApiClient.Dto
{
    public class AddressDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string StreetName { get; set; }

    }
}
