namespace Scheduler.Interfaces;

/// <summary>
/// Encapsulates the five most common CRUDS to be reused
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDaoAsync<T>
{
    public Task<IEnumerable<T>> GetAllAsync();

    public Task<T> GetByIdAsync(int id);

    public Task<int> AddAsync(T entity);

    public Task<bool> DeleteAsync(int id);

    public Task<bool> UpdateAsync(T entity);
}