using Dapper;
using Scheduler.Interfaces;
using Scheduler.Model;
using System.Data.SqlClient;

namespace Scheduler.Dal;

//Work in progess not done yet is for future versions
public class ProjectDao : IDaoAsync<Project>
{
    private readonly string _connectionString = default!;

    private const string _getAllProjectsCommandText =
        "SELECT project.id AS ProjectId, name, description, address, start_date AS StartDate, end_date AS EndDate FROM Project";

    private const string _getProjectByIdCommandText =
        "SELECT project.id AS ProjectId, name, description, address, start_date AS StartDate, end_date AS EndDate FROM Project WHERE id = @Id";

    private const string _InsertProjectCommandText =
        "INSERT INTO Project (project_id, name, description, address, start_date, end_date) OUTPUT INSERTED.Id " +
        "VALUES (@ProjectId, @Name, @Description, @StartDate, @EndDate)";

    private const string _deleteProjectByIdCommandText =
        "DELETE FROM Project WHERE id = @Id";

    private const string _updateProjectCommandText =
        "UPDATE Project SET name = @Name, description = @Description, start_date = @StartDate, end_date = @EndDate";

    public ProjectDao(string connection)
    {
        _connectionString = connection;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                var projects = await connection.QueryAsync<Project>(_getAllProjectsCommandText);
                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get projects: {ex}");
            }
        }
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                var project = await connection.QuerySingleOrDefaultAsync<Project>(_getProjectByIdCommandText, new { Id = id });
                return project;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get project: {ex}");
            }
        }
    }

    public async Task<int> AddAsync(Project project)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                int projectId = await connection.QuerySingleAsync<int>(_InsertProjectCommandText, project);
                if (projectId == 0)
                {
                    return 0;
                }
                return projectId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Project could not be created: {ex}");
            }
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                int affectedRows = await connection.ExecuteAsync(_deleteProjectByIdCommandText, new { Id = id });
                if (affectedRows == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Project could not be deleted: {ex}");
            }
        }
    }

    public async Task<bool> UpdateAsync(Project project)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                int affectedRows = await connection.ExecuteAsync(_updateProjectCommandText, project);
                if (affectedRows == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Project could not be updated: {ex}");
            }
        }
    }
}