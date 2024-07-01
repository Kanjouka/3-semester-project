namespace Scheduler.Interfaces;

/// <summary>
/// Interface for all CRUDS for Employee
/// </summary>
public interface IEmployeeDao<T> : IDaoAsync<T>
{
    /// <summary>
    /// Creates a Employee
    /// </summary>
    /// <param name="employee"> Employee object </param>
    /// <returns>a employeeID (int) </returns>
    public Task<T> LoginAsync(string email, string password);
}