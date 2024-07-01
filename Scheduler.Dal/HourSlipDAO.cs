using Dapper;
using Scheduler.Interfaces;
using Scheduler.Model;
using System.Data;
using System.Data.SqlClient;

namespace Scheduler.Dal;

public class HourSlipDao : IHourSlipDaoAsync<HourSlip>
{
    private readonly string _connectionString = default!;

    private const string _getTotalMinutesInProjectCommandText =
        @"SELECT
        project.id AS ProjectId,
        total_minutes AS TotalMinutesInt
    FROM project
    WHERE project.id = @ProjectId";

    private const string _createHourSlipCommandText =
        @"INSERT INTO hour_slip
    (employee_id_fk, project_id_fk, date, start_time, end_time, is_approved)
    OUTPUT INSERTED.Id
    VALUES (@EmployeeID, @ProjectId, @Date, @StartTime, @EndTime, @IsApproved)";

    private const string _updateTotalMinutesInProjectCommandText =
        @"UPDATE Project
    SET total_minutes = @TotalMinutesInt
    WHERE project.id = @ProjectId";

    private const string _approveCommandText =
        "UPDATE hour_slip SET is_approved = 1 WHERE id = @Id AND row_version = @RowVersion";

    private const string _deleteCommandText = "DELETE FROM hour_slip WHERE id = @id";

    private const string _getAllHourSlipsCommandText =
        "SELECT id, employee_id_fk AS EmployeeId, project_id_fk AS ProjectId, date, start_time AS StartTime, " +
        "row_version AS RowVersion, end_time AS EndTime, is_approved AS IsApproved FROM hour_slip";

    private const string _getAllHourSlipsFromEmployeeByIdCommandText =
        "SELECT id, employee_id_fk AS EmployeeId, project_id_fk AS ProjectId, date, start_time AS StartTime, " +
        "end_time AS EndTime, is_approved AS IsApproved, row_version AS RowVersion FROM hour_slip " +
        "WHERE employee_id_fk = @employee_Id ORDER BY [date] DESC";

    private const string _getTop50UnapprovedHourSlipsCommandText =
        "SELECT TOP 50 id, employee_id_fk AS EmployeeId, project_id_fk AS ProjectId, date, start_time AS StartTime, " +
        "end_time AS EndTime, is_approved AS IsApproved, row_version AS RowVersion FROM hour_slip WHERE is_approved = 0";

    private const string _getHourSlipByIdCommandText =
        "SELECT id, employee_id_fk AS EmployeeId, project_id_fk AS ProjectId, date, start_time AS StartTime, " +
        "end_time AS EndTime, is_approved AS IsApproved, row_version AS RowVersion FROM hour_slip WHERE id = @id";

    private const string _getTotalHoursInProjectCommandText =
        @"SELECT
        project.id AS ProjectId,
        total_minutes AS TotalMinutesInt
    FROM project
    WHERE project.id = @ProjectId";

    private const string _updateHourSlipCommandText =
        @"UPDATE hour_slip
    SET
        start_time = @StartTime,
        end_time = @EndTime
    WHERE id = @Id
    AND row_version = @RowVersion";

    private const string _updateTotalHoursInProjectCommandText =
        @"UPDATE
        Project
    SET
        total_minutes = @TotalMinutesInt
    WHERE
        project.id = @ProjectId";

    public HourSlipDao(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Saves an Hour Slip in the database.
    /// </summary>
    /// <param name="hourSlip">HourSlip object </param>
    /// <returns>The created Hour Slips id.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<int> AddAsync(HourSlip hourSlip)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            try
            {
                int hourSlipId = await connection.QuerySingleAsync<int>(_createHourSlipCommandText, hourSlip, transaction);
                if (hourSlipId == 0) { return 0; }

                //Get project and total_minutes from DB and map to object.
                Project project = await connection.QuerySingleAsync<Project>(_getTotalMinutesInProjectCommandText, hourSlip, transaction);
                //Calculate the number of worked hours in HourSlip
                TimeSpan workedHours = (hourSlip.EndTime - hourSlip.StartTime);
                //convert it into total minutes and cast it to int
                project.TotalMinutesInt += (int)workedHours.TotalMinutes;

                Thread.Sleep(2000);
                await connection.ExecuteAsync(_updateTotalMinutesInProjectCommandText, project, transaction);

                transaction.Commit();
                return hourSlipId;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"The HourSlip could not be added to the database: {ex.Message}");
            }
        }
    }

    public async Task<bool> ApproveHourSlip(HourSlip hourSlip)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            try
            {
                int row = await connection.ExecuteAsync(_approveCommandText, hourSlip);
                if (row == 0) { return false; }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Hour Slip could not be updated: {ex}");
            }
        }
    }

    /// <summary>
    /// Deletes an Hour Slip in database.
    /// </summary>
    /// <param name="hourSlipId">Integer value for Hour Slip id.</param>
    /// <returns>Returns true if successfully deleted based on Id, otherwise false.</returns>
    public async Task<bool> DeleteAsync(int hourSlipId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            try
            {
                HourSlip hourSlip = await GetByIdAsync(hourSlipId);

                int rows = await connection.ExecuteAsync(_deleteCommandText, new { id = hourSlipId }, transaction);
                if (rows == 0) { return false; }

                Project project = await connection.QuerySingleAsync<Project>(_getTotalHoursInProjectCommandText, hourSlip, transaction);

                TimeSpan deletedDuration = hourSlip.EndTime - hourSlip.StartTime;

                TimeSpan totalHours = TimeSpan.FromMinutes(project.TotalMinutesInt);

                totalHours = totalHours.Subtract(deletedDuration);

                project.TotalMinutesInt = (int)totalHours.TotalMinutes;

                await connection.ExecuteAsync(_updateTotalHoursInProjectCommandText, project, transaction);

                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"The HourSlip could not be deleted: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Get all Hour Slips from Database.
    /// </summary>
    /// <returns>Returns IEnumerable<HourSlip></returns>
    public async Task<IEnumerable<HourSlip>> GetAllAsync()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            try
            {
                IEnumerable<HourSlip> hourSlips = await connection.QueryAsync<HourSlip>(_getAllHourSlipsCommandText);
                if (!hourSlips.Any()) { return Enumerable.Empty<HourSlip>(); }

                return hourSlips;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get all HourSlips: {ex.Message}");
            }
        }
    }

    public async Task<IEnumerable<HourSlip>> GetAllHourSlipsFromEmployeeAsync(int employeeId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            try
            {
                IEnumerable<HourSlip> hourSlips = await connection.QueryAsync<HourSlip>(_getAllHourSlipsFromEmployeeByIdCommandText, new { employee_Id = employeeId });
                if (!hourSlips.Any()) { return Enumerable.Empty<HourSlip>(); }

                return hourSlips;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get all HourSlips: {ex.Message}");
            }
        }
    }

    public async Task<IEnumerable<HourSlip>> GetAllUnapprovedHourSlipsAsync()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            try
            {
                IEnumerable<HourSlip> hourSlips = await connection.QueryAsync<HourSlip>(_getTop50UnapprovedHourSlipsCommandText);
                if (!hourSlips.Any()) { return Enumerable.Empty<HourSlip>(); }

                return hourSlips;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get unapproved HourSlips: {ex}");
            }
        }
    }

    public async Task<HourSlip> GetByIdAsync(int hourSlipId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            HourSlip hourSLip = await connection.QueryFirstOrDefaultAsync<HourSlip>(_getHourSlipByIdCommandText, new { id = hourSlipId });
            return hourSLip;
        }
    }

    //Små problemer. Hvis en editer sit hourslip til at være en korter arbejdsdag så vil totalhours ikke blive mindre men større da vi altid + på
    //Vil ikke opdatere totalhours (har ikke sat mig ind i hvorfor)
    //Vi skal vælge mellem minutes eller hours
    //Hvis du bare trykker edit (uden at edit den) så vil det også tilføje extra tid selvom vi ikke har ændret hourslip.
    public async Task<bool> UpdateAsync(HourSlip newHourSlip)
    {
        HourSlip oldHourSlip = await GetByIdAsync(newHourSlip.Id);
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            try
            {
                int row = await connection.ExecuteAsync(_updateHourSlipCommandText, newHourSlip, transaction);
                if (row == 0) { return false; }

                Project project = await connection.QuerySingleAsync<Project>(_getTotalHoursInProjectCommandText, newHourSlip, transaction);
                // Calculate the duration of the old and new hour slips
                TimeSpan oldDuration = oldHourSlip.EndTime - oldHourSlip.StartTime;
                TimeSpan newDuration = newHourSlip.EndTime - newHourSlip.StartTime;

                // Convert total_minutes to TimeSpan
                TimeSpan totalHours = TimeSpan.FromMinutes(project.TotalMinutesInt);

                // Update total hours
                totalHours = totalHours.Subtract(oldDuration);
                totalHours = totalHours.Add(newDuration);

                // Convert total hours back to minutes and cast to int
                project.TotalMinutesInt = (int)totalHours.TotalMinutes;
                Thread.Sleep(2500);
                await connection.ExecuteAsync(_updateTotalHoursInProjectCommandText, project, transaction);

                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Hour Slip could not be updated: {ex}");
            }
        }
    }
}