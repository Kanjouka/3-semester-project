namespace Scheduler.ApiClient.Dto;

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public AddressDto Address { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public override string ToString()
    {
        return $"Id: {EmployeeId} Name: {FirstName} {LastName}";
    }
}