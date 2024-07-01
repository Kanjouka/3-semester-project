using Dapper;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Scheduler.Dal;
using Scheduler.Interfaces;
using Scheduler.Model;
using System.Data.SqlClient;

namespace Scheduler.Test.DalTest;

[TestFixture]
public class EmployeeTest
{
    /*                              Attention :) (See as guide but dont follow blindly -- we might have done some mistakes :))
    *      We have followed Microsoft documentation "Best Practice for unit testing"
    *      Practices:
    *       1. Method names consists of three parts - Name of method being tested, scenario under which it's tested and the expected behavior when invoked.
    *           - Eks. Public void CreateEmployee_Employee_ReturnsEmployeeID
    *       2. Followes AAA pattern
    *       3. Input should be simple as possible (Write minimally passing tests)
    *       4. Should only contain one Act per test -- (might not work for integration test)
    *       5. No logic in test
    *       6. Use [TestCase] if you need to test the same method with different input (don't have to create a new method)
    *       7. Use parameterized test (if it makes sense and fits)
    *       8. If a behavior can be tested using either a unit test or an integration test, choose the unit test.
    *
    *       Link to documentation --> https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
    *                                 https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0
    *
    *
    *
    *
    */

    #region Fields
    private string _developer;
    private IEmployeeDao<Employee> employeeDAO;
    private List<int> employeeIds;
    string _connectionString = @"";

    #endregion Fields

    [SetUp]
    public void Setup()
    {
        //Guid
        string developerGuid = Guid.NewGuid().ToString("N");
        //Write your name
        _developer = developerGuid + "Developer Name";
        //Access to database
        employeeDAO = new EmployeeDao(_connectionString);
        //Set up list for employees id
        employeeIds = new List<int>();
        //Setup test data
        insertTestData();
    }

    [Category("Database")]
    [Description("Integration test for create a employee in Database")]
    [Test]
    public async Task CreateEmplpyee_CreationOfEmployeeIsSuccesful_ReturnsEmployeeID()
    {
        //Arrange
        Address adress = new Address("7800", "Skive", "Lindev�nget", "42");
        Employee employee = new Employee(_developer, "James", "James@hotmail.com", "password123");
        employee.PhoneNumber = "1234";
        employee.Role = "Manager";
        employee.Address = adress;
        //Act
        int actualID = await employeeDAO.AddAsync(employee);
        //Assert
        int expectedID = selectEmployeeIdById(actualID);
        string errorMessage = $"Test Failed: actualID should equal to expectedID: actualID: {actualID}, expectedID{expectedID}";
        Assert.That(actualID, Is.EqualTo(expectedID), errorMessage);
    }

    [Category("Database")]
    [Description("Integration test for deleting a employee when id is valid in Database")]
    [Test]
    public async Task DeleteEmployee_WhenEmployeeIDIsValid_ReturnsTrue()
    {
        //Arrange
        int employeeIdToDelete = employeeIds[0];
        //Act
        bool expectedTrue = await employeeDAO.DeleteAsync(employeeIdToDelete);
        //Assert
        string errorMessage = $"Test Failed: Should have returned true: Expected: {true}, Actual: {expectedTrue}";
        Assert.IsTrue(expectedTrue, errorMessage);
    }

    [Category("Database")]
    [Description("Integration test for deleting a employee when id is invalid in Database")]
    [Test]
    public async Task DeleteEmployee_WhenEmployeeIDIsInvaild_ReturnsFalse()
    {
        //Arrange
        int invalidID = -1;
        //Act
        bool expectedFalse = await employeeDAO.DeleteAsync(invalidID);
        //Assert
        string ErrorMessage = $"Test Failed: Should not delete anything and return false: Expected {false} Actual:{expectedFalse}";
        Assert.IsFalse(expectedFalse, ErrorMessage);
    }

    [Category("Database")]
    [Description("Integration test for getting all employees in Database")]
    [Test]
    public async Task GetAllEmployees_Employees_ReturnsIEnumerableOfEmployees()
    {
        //Arrange
        IEnumerable<int> employeesId = employeeIds;
        //Act
        IEnumerable<Employee> employees = await employeeDAO.GetAllAsync();
        //Assert
        string errorMessage = $"Test Failed: employees should contain have the same count value: Expected: {employeesId.Count()}, Actual {employees.Count()}";
        Assert.That(employeesId.Count(), Is.EqualTo(employees.Count()), errorMessage);
    }

    [Category("Database")]
    [Description("Integration test for updating a employee when employeeid is valid in Database")]
    [TestCase("Harry", "Peter", "Harry@hotmail.com")]
    public async Task UpdateEmployee_WhenEmployeeIDIsVaild_ReturnsTrue(string name, string lastname, string email)
    {
        //Arrange
        Employee employee = new Employee(_developer, lastname, email);
        employee.EmployeeId = employeeIds[0];
        //Act
        bool expectedTrue = await employeeDAO.UpdateAsync(employee);
        //Assert
        string errorMessage = $"Test Failed: Should have updated employee: Expected: {true}, Actual {expectedTrue}";
        Assert.IsTrue(expectedTrue, errorMessage);
    }

    [Category("Database")]
    [Description("Integration test for updating a employee when id is invalid in Database")]
    [TestCase("Mike", "Jerry", "Mike@hotmail.com", "middlePassword", -6)]
    public async Task UpdateEmployee_WhenEmployeeIDIsInvaild_ReturnsFalse(string name, string lastname, string email, string password, int id)
    {
        //Arrange
        Employee employee = new Employee(_developer, lastname, email, password);
        employee.EmployeeId = id;
        //Act
        bool expectedFalse = await employeeDAO.UpdateAsync(employee);
        //Assert
        string errorMessage = $"Test Failed: Should not have updated employee in database: False Actual: {expectedFalse}";
        Assert.IsFalse(expectedFalse, errorMessage);
    }

    [Category("Database")]
    [Description("Integration test for selecting a employee from database")]
    [Test]
    public async Task SelectEmployee_WhenSelectionOfEmployeeIsSuccesful_returnsEmployee()
    {
        //Arrange
        int expectedEmployeeId = employeeIds[0];
        //Act
        Employee employee = await employeeDAO.GetByIdAsync(expectedEmployeeId);
        int actualEmployeeId = employee.EmployeeId;
        //Assert
        Assert.That(actualEmployeeId, Is.EqualTo(expectedEmployeeId));
    }


    [TearDown]
    public void TearDown()
    {
        int rows = 0;
        string delete = $"delete from employee where first_name = @name";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(delete, connection);

            cmd.Parameters.AddWithValue("name", _developer);

            rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"TearDown method has been activated: {rows} rows has been deleted from employee table");
        }
    }

    #region helper_methods
    public void insertTestData()
    {
        List<Employee> testData = CreateEmployeeTestData();

        string addressCommandText = "INSERT INTO address (street_name, street_number, zip) OUTPUT INSERTED.Id " +
            "VALUES (@StreetName, @StreetNumber, @ZipCode)";
        string employeeCommandText = "INSERT INTO Employee (first_name, last_name, email, [hashed_password], role_id_fk, phone_number,address_id_fk) OUTPUT INSERTED.Id " +
            "VALUES (@FirstName, @Lastname, @Email, @Password, @RoleId, @PhoneNumber, @AddressID)";

        string checkZipCodeCommandText = "IF NOT EXISTS (SELECT 1 FROM city WHERE zip = @ZipCode) BEGIN INSERT INTO city (zip, city_name) OUTPUT INSERTED.zip " +
                                       "VALUES (@ZipCode,@City) END " +
                                       "ELSE BEGIN SELECT zip FROM city WHERE zip = @ZipCode AND city_name = @City END";

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            foreach (var employee in testData)
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute(checkZipCodeCommandText, employee.Address, transaction);
                        employee.AddressID = connection.QuerySingle<int>(addressCommandText, employee.Address, transaction);

                        int roleId = GetRoleIdByRoleName(employee.Role);
                        employee.RoleId = roleId;
                        int employeeId = connection.QuerySingle<int>(employeeCommandText, employee, transaction);
                        transaction.Commit();
                        employeeIds.Add(employeeId);

                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        throw new Exception($"Employee could not be created: {ex}");
                    }
                        

                    
                }   
            }
                
        }
    }
    

    public List<Employee> CreateEmployeeTestData()
    {
        Address address0 = new Address("7800", "Skive", "Gadenavn", "42");
        Address address1 = new Address("9000", "Aalborg", "Alle", "142");
        List<Employee> testData = new List<Employee>
        {
            new Employee {FirstName = _developer, LastName = "James", Email = "James@hotmail.com", Password = "MiddlePassword123", Role = "Employee", PhoneNumber = "3465", Address = address0},
            new Employee {FirstName = _developer, LastName = "Potter", Email = "Potter@hotmail.com", Password = "WizardPassword123", Role = "Admin", PhoneNumber = "4576", Address = address1}
        };
        return testData;
    }

    public int selectEmployeeIdById(int id)
    {
        string selectEmployeeIDById = $"SELECT id FROM employee where id = @id";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            int employeeId = 0;
            SqlCommand cmd = new SqlCommand(selectEmployeeIDById, connection);
            connection.Open();
            try
            {
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    employeeId = (int)reader["id"];
                }

                return employeeId;
            }
            catch (Exception ex)
            {

                throw new Exception($"Could not select Employee by ID {ex}");
            }
        }
    }
    public int GetRoleIdByRoleName(string roleName)
    {
        string selectRoleByRoleName = $"SELECT id FROM [role] WHERE role_name = @RoleName";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            int roleId = connection.QuerySingle<int>(selectRoleByRoleName, new { RoleName = roleName });
            return roleId;
        }
    }

    #endregion
}