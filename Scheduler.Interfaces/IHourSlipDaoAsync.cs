
namespace Scheduler.Interfaces;

public interface IHourSlipDaoAsync<T> : IDaoAsync<T>
{
    public Task<IEnumerable<T>> GetAllUnapprovedHourSlipsAsync();

    public Task<IEnumerable<T>> GetAllHourSlipsFromEmployeeAsync(int employeeID);

    public Task<bool> ApproveHourSlip(T entity);
}