using Dapper;
using Scheduler.Interfaces;
using Scheduler.Model;
using System.Data.SqlClient;

namespace Scheduler.Dal;
/*
 * Missing transactions, try-catch and might need to refactor its null checking logic.
 * Otherwise it has passed all tests and ready for consumption
 */

public class EmployeeDao : IEmployeeDao<Employee>
{
    private readonly string _connectionString = default!;

    private const string _insertAddressCommandText =
    "INSERT INTO address (street_name, street_number, zip) OUTPUT INSERTED.Id " +
    "VALUES (@StreetName, @StreetNumber, @ZipCode)";

    private const string _insertEmployeeCommandText =
        "INSERT INTO Employee (first_name, last_name, email, [hashed_password], role_id_fk, phone_number, address_id_fk) OUTPUT INSERTED.Id " +
        "VALUES (@FirstName, @Lastname, @Email, @Password, @RoleId, @PhoneNumber, @AddressID)";

    private const string _checkZipCodeCommandText =
        "IF NOT EXISTS (SELECT 1 FROM city WHERE zip = @ZipCode) " +
        "BEGIN " +
        "INSERT INTO city (zip, city_name) OUTPUT INSERTED.zip " +
        "VALUES (@ZipCode, @City) " +
        "END " +
        "ELSE " +
        "BEGIN " +
        "SELECT zip FROM city WHERE zip = @ZipCode AND city_name = @City " +
        "END";

    private const string _deleteEmployeeCommandText = "DELETE FROM employee WHERE id = @id";

    private const string _getAllEmployeesCommandText =
        "SELECT e.id AS EmployeeID, e.first_name AS FirstName, e.last_name AS LastName, e.email, role_name AS Role, " +
        "e.phone_number AS PhoneNumber, a.street_number AS StreetNumber, c.zip AS ZipCode, a.street_name AS StreetName, " +
        "c.city_name AS City " +
        "FROM Employee e " +
        "JOIN Address a ON e.address_id_fk = a.id " +
        "JOIN city c ON a.zip = c.zip " +
        "LEFT JOIN role ON e.role_id_fk = role.id";

    private const string _getEmployeeByIdCommandText =
        "SELECT e.id AS EmployeeID, e.first_name AS FirstName, e.last_name AS LastName, e.email, role_name AS Role, " +
        "e.phone_number AS PhoneNumber, a.street_number AS StreetNumber, c.zip AS ZipCode, a.street_name AS StreetName, " +
        "c.city_name AS City " +
        "FROM Employee e " +
        "JOIN Address a ON e.address_id_fk = a.id " +
        "JOIN city c ON a.zip = c.zip " +
        "LEFT JOIN role ON e.role_id_fk = role.id " +
        "WHERE e.id = @EmployeeId";

    private const string _checkPasswordCommandText =
        "SELECT hashed_password FROM employee WHERE email = @Email";

    private const string _getEmployeeByEmailCommandText =
        "SELECT employee.id AS EmployeeId, first_name AS FirstName, last_name AS LastName, email, role_name AS Role " +
        "FROM employee " +
        "JOIN role ON role_id_fk = role.id " +
        "WHERE email = @Email";

    private const string _updateEmployeeCommandText =
        "UPDATE Employee " +
        "SET first_name = @FirstName, last_name = @Lastname, email = @Email, phone_number = @PhoneNumber " +
        "WHERE id = @EmployeeId";

    private const string _selectRoleByRoleName =
        "SELECT id FROM [role] WHERE role_name = @RoleName";

    /// <summary>
    /// Connection to database
    /// </summary>
    /// <param name="connection"></param>
    public EmployeeDao(string connection)
    {
        _connectionString = connection;
    }

    /// <summary>
    /// Saves a Employee in database
    /// </summary>
    /// <param name="employee"> Employee object </param>
    /// <returns> employee's id </returns>
    /// <exception cref="Exception"></exception>
    public async Task<int> AddAsync(Employee employee)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var generatedSalt = BCryptTool.GenerateSalt();
                    employee.Password = BCryptTool.HashPassword(employee.Password, generatedSalt);

                    await connection.ExecuteAsync(_checkZipCodeCommandText, employee.Address, transaction);
                    employee.AddressID = await connection.QuerySingleAsync<int>(_insertAddressCommandText, employee.Address, transaction);

                    int roleId = GetRoleIdByRoleName(employee.Role);
                    employee.RoleId = roleId;
                    int employeeId = await connection.QuerySingleAsync<int>(_insertEmployeeCommandText, employee, transaction);

                    transaction.Commit();

                    return employeeId;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Employee could not be created: {ex}");
                }
            }
        }
    }

    /// <summary>
    /// Deletes a Employee in database
    /// </summary>
    /// <param name="Employeeid"> interger employee's id </param>
    /// <returns>True if employee id is valid otherwise false</returns>
    public async Task<bool> DeleteAsync(int employeeid)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            int rows = await connection.ExecuteAsync(_deleteEmployeeCommandText, new { id = employeeid });
            if (rows == 0)
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Retrives all Employees from database
    /// </summary>
    /// <returns>IEnumerable<Employee></returns>
    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var employees = await connection.QueryAsync<Employee, Address, Employee>(_getAllEmployeesCommandText,
                (employee, address) =>
                { employee.Address = address; return employee; }, splitOn: "StreetNumber");

            return employees;
        }
    }

    /// <summary>
    /// Retrives Employee
    /// </summary>
    /// <param name="employeeId"> interger employee's id</param>
    /// <returns>Employee</returns>
    public async Task<Employee> GetByIdAsync(int employeeId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var employees = await connection.QueryAsync<Employee, Address, Employee>(
                _getEmployeeByIdCommandText,
                (employee, address) =>
                {
                    employee.Address = address;
                    return employee;
                },
                new { EmployeeId = employeeId },
                splitOn: "StreetNumber");

            return employees.FirstOrDefault();
        }
    }

    public async Task<Employee> LoginAsync(string email, string password)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var employeeHasedPassword = await connection.QueryFirstOrDefaultAsync<string>(_checkPasswordCommandText, new { email });
            if (employeeHasedPassword == null)
            {
                return null;
            }
            var isCorrect = BCryptTool.ValidateHashPassword(password, employeeHasedPassword);
            if (!isCorrect)
            {
                return null;
            }
            return await connection.QueryFirstOrDefaultAsync<Employee>(_getEmployeeByEmailCommandText, new { email });
        }
    }

    /// <summary>
    /// Updates a employee in database
    /// </summary>
    /// <param name="employee"> A Employee object</param>
    /// <returns> True if update was succesful otherwise false</returns>
    /// <exception cref="Exception">Employee could not be updated</exception>
    public async Task<bool> UpdateAsync(Employee employee)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                int row = await connection.ExecuteAsync(_updateEmployeeCommandText, employee);

                if (row == 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Employee could not be updated: {ex}");
            }
        }
    }

    private int GetRoleIdByRoleName(string roleName)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            int roleId = connection.QuerySingle<int>(_selectRoleByRoleName, new { RoleName = roleName });
            return roleId;
        }
    }
}