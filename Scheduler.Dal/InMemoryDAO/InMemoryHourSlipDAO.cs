using Scheduler.Interfaces;
using Scheduler.Model;

namespace Scheduler.Dal.InMemoryDAO;

public class InMemoryHourSlipDAO : IHourSlipDaoAsync<HourSlip>
{
    private List<HourSlip> _hourSlips = new List<HourSlip>();

    public InMemoryHourSlipDAO()
    {
        for (int i = 0; i < 10; i++)
        {
            AddAsync(new HourSlip()
            {
                Id = i,
                EmployeeId = i,
                IsApproved = false,
                Date = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(8),
            }).Wait();
        }
    }

    public async Task<int> AddAsync(HourSlip hourSlip)
    {
        hourSlip.Id = _hourSlips.Count + 1;
        _hourSlips.Add(hourSlip);
        return hourSlip.Id;
    }

    public Task<bool> ApproveHourSlip(int hourSlipID)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ApproveHourSlip(HourSlip entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return _hourSlips.Remove(await GetByIdAsync(id));
    }

    public async Task<IEnumerable<HourSlip>> GetAllAsync()
    {
        return _hourSlips;
    }

    public async Task<IEnumerable<HourSlip>> GetAllHourSlipsFromEmployeeAsync(int employeeID)
    {
        return _hourSlips.Where(hourslip => hourslip.EmployeeId == employeeID); ;
    }

    public async Task<IEnumerable<HourSlip>> GetAllUnapprovedHourSlipsAsync()
    {
        return _hourSlips.Where(hourslip => hourslip.IsApproved == false);
    }

    public async Task<IEnumerable<HourSlip>> GetAllUnapprovedHourSlipsFromEmployeeAsync(int employeeID)
    {
        return _hourSlips.Where(hourslip => hourslip.EmployeeId == employeeID && hourslip.IsApproved == false);
    }

    public async Task<HourSlip?> GetByIdAsync(int id)
    {
        return _hourSlips.FirstOrDefault(hourslip => hourslip.Id == id);
    }

    public async Task<bool> UpdateAsync(HourSlip hourSlip)
    {
        HourSlip hourSlipToUpdate = await GetByIdAsync(hourSlip.Id);
        if (hourSlipToUpdate == null) { return false; }
        hourSlipToUpdate.Date = hourSlip.Date;
        hourSlipToUpdate.IsApproved = hourSlip.IsApproved;
        return true;
    }
}