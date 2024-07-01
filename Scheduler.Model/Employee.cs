using System.ComponentModel.DataAnnotations;

namespace Scheduler.Model;

public class Employee
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

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;

    public Address? Address { get; set; }
    public int? AddressID { get; set; }
    public string Role { get; set; }

    public int RoleId { get; set; }

    public string PhoneNumber { get; set; }

    public Employee(string firstname, string lastname, string email, string password)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        Password = password;
    }

    public Employee(string firstname, string lastname, string email)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
    }

    public Employee(string firstname, string lastname, string email, string role, string phonenumber, Address address)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        Role = role;
        PhoneNumber = phonenumber;
        Address = address;
    }

    public Employee()
    {
    }
}