using RestSharp;
using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;
using System.Net;
using ThirdSemester.ApiClient;

namespace Scheduler.ApiClient;

public class EmployeeApiClient : IEmployeeDao<EmployeeDto>
{
    private readonly RestClient _restClient;

    public EmployeeApiClient(string uri)
    {
        _restClient = new RestClient(uri);
    }

    public async Task<int> AddAsync(EmployeeDto entity)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, "/employees", entity);
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error creating employee with id={entity.EmployeeId}. Message was {response.Content}");
        }
        return response.Data;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _restClient.RequestAsync<bool>(Method.Delete, $"/employees/{id}");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error deleting employee with id={id}. Message was {response.Content}");
        }
        return true;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        var response = await _restClient.RequestAsync<IEnumerable<EmployeeDto>>(Method.Get, "/employees");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving all employees. Message was {response.Content}");
        }
        //Oneliner checking the response for data. If no data, return empty Enumerable.
        //Remaining methods will use classic if statement.
        return response.Data ?? Enumerable.Empty<EmployeeDto>();
    }

    public async Task<EmployeeDto> GetByIdAsync(int id)
    {
        var response = await _restClient.RequestAsync<EmployeeDto>(Method.Get, $"/employees/{id}");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving employee with id={id}. Message was {response.Content}");
        }
        return response.Data;
    }

    public async Task<EmployeeDto> LoginAsync(string email, string password)
    {
        var response = await _restClient.RequestAsync<EmployeeDto>(Method.Post, "/accounts", new LoginDto() { Email = email, Password = password });
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error login with {email} and {password}. Message was {response.Content}");
        }
        return response.Data;
    }

    public async Task<bool> UpdateAsync(EmployeeDto entity)
    {
        var response = await _restClient.RequestAsync<bool>(Method.Put, $"/employees", entity);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        else
        {
            throw new Exception($"Error updating employee with id={entity.EmployeeId}. Message was {response.Content}");
        }
    }
}