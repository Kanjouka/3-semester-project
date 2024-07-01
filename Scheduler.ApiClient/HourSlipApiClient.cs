using RestSharp;
using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;
using Scheduler.Model;
using System.Net;
using ThirdSemester.ApiClient;

namespace Scheduler.ApiClient;

public class HourSlipApiClient : IHourSlipDaoAsync<HourSlipDto>
{
    //comment do we want to have one ApiClient handling all connection to database?
    //Will this require commenting the code, as we'll have an add(HourSlipDto) and add(EmployeeDto) methods.
    private readonly RestClient _restClient;

    public HourSlipApiClient(string uri)
    {
        _restClient = new RestClient(uri);
    }

    public async Task<int> AddAsync(HourSlipDto entity)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, "/hourSlips", entity);
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error creating hourslip with id={entity.Id}. Message was {response.Content}");
        }
        return response.Data;
    }

    public async Task<bool> ApproveHourSlip(HourSlipDto hourSlip)
    {
        var response = await _restClient.RequestAsync<bool>(Method.Put, $"/hourslips/approve", hourSlip);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return response.Data;
        }
        else
        {
            throw new Exception($"Error updating hourslip with id={hourSlip.Id}. Message was {response.Content}");
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _restClient.RequestAsync<bool>(Method.Delete, $"/hourSlips/{id}");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error deleting hourslip with id={id}. Message was {response.Content}");
        }
        return true;
    }

    public async Task<IEnumerable<HourSlipDto>> GetAllAsync()
    {
        var response = await _restClient.RequestAsync<IEnumerable<HourSlipDto>>(Method.Get, "/hourSlips");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving all hourslip. Message was {response.Content}");
        }
        //Oneliner checking the response for data. If no data, return empty Enumerable.
        //Remaining methods will use classic if statement.
        return response.Data ?? Enumerable.Empty<HourSlipDto>();
    }

    public async Task<IEnumerable<HourSlipDto>> GetAllHourSlipsFromEmployeeAsync(int employeeID)
    {
        var response = await _restClient.RequestAsync<IEnumerable<HourSlipDto>>(Method.Get, $"/hourslips/employees/{employeeID}/");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving all hourslip from employee with id={employeeID}. Message was {response.Content}");
        }
        if (response.Data != null)
        {
            return response.Data;
        }
        return Enumerable.Empty<HourSlipDto>();
    }

    public async Task<IEnumerable<HourSlipDto>> GetAllUnapprovedHourSlipsAsync()
    {
        var response = await _restClient.RequestAsync<IEnumerable<HourSlipDto>>(Method.Get, "/hourslips/unapproved");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving all unapproved hourslip. Message was {response.Content}");
        }
        if (response.Data != null)
        {
            return response.Data;
        }
        return Enumerable.Empty<HourSlipDto>();
    }

    public async Task<HourSlipDto> GetByIdAsync(int id)
    {
        var response = await _restClient.RequestAsync<HourSlipDto>(Method.Get, $"/hourSlips/{id}");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving hourslip with id={id}. Message was {response.Content}");
        }
        if (response.Data != null)
        {
            return response.Data;
        }
        return new HourSlipDto();
        //Maybe throw exception instead of returning empty HourSlipDto?
        //throw new Exception($"Employee with id={id} not found");
    }

    public async Task<bool> UpdateAsync(HourSlipDto entity)
    {
        var response = await _restClient.RequestAsync<bool>(Method.Put, $"/hourSlips", entity);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        else
        {
            throw new Exception($"Error updating hourslip with id={entity.Id}. Message was {response.Content}");
        }
    }
}