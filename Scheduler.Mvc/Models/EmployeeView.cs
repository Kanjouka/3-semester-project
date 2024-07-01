using System.ComponentModel.DataAnnotations;

namespace Scheduler.Mvc.Models;

public class EmployeeView
{
    [Key]
    [Required]
    public int EmployeeId { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;


    public string Role { get; set; }

    public EmployeeView(string firstname, string lastname, string email, string password)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        Password = password;
    }

    public EmployeeView()
    {
    }
}