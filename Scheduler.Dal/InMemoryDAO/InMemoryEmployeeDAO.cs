using Scheduler.Interfaces;
using Scheduler.Model;

namespace Scheduler.Dal.InMemoryDAO;

public class InMemoryEmployeeDAO : IEmployeeDao<Employee>
{
    private List<Employee> _employees = new List<Employee>();

    public InMemoryEmployeeDAO()
    {
        //Make 10 inmemory _employees and add them to the list
        for (int i = 0; i < 10; i++)
        {
            AddAsync(new Employee()
            {
                EmployeeId = i,
                FirstName = $"Bo{i}",
                LastName = $"Jensen{i}",
            }).Wait();
        }
    }

    public async Task<int> AddAsync(Employee employee)
    {
        employee.EmployeeId = _employees.Count + 1;
        _employees.Add(employee);
        return employee.EmployeeId;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Employee employeeToDelette = await GetByIdAsync(id);
        if (employeeToDelette == null) { return false; }
        return _employees.Remove(employeeToDelette);
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return _employees;
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return _employees.FirstOrDefault(employee => employee.EmployeeId == id);
    }

    public Task<Employee> LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Employee employee)
    {
        Employee employeeToUpdate = await GetByIdAsync(employee.EmployeeId);
        if (employeeToUpdate == null) { return false; }
        employeeToUpdate.FirstName = employee.FirstName;
        employeeToUpdate.LastName = employee.LastName;
        employeeToUpdate.Email = employee.Email;
        return true;
    }
}