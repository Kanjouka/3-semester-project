using System.ComponentModel.DataAnnotations;

namespace Scheduler.Model
{
    public class Address
    {
        
        [Required]
        public string City { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string StreetName { get; set; }

        public Address(string city, string streetNumber, string zipCode, string streetName)
        {
            City = city;
            StreetNumber = streetNumber;
            ZipCode = zipCode;
            StreetName = streetName;
        }

        public Address()
        {

        }
    }
}