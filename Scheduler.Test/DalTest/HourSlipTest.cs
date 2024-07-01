using Scheduler.Dal;
using Scheduler.Interfaces;
using Scheduler.Model;
using System.Data.SqlClient;

namespace Scheduler.Test.DalTest;

public class HourSlipTest
{
    #region Fields
    string _connectionString = @"";
    string _developerID;
    IHourSlipDaoAsync<HourSlip> _hourSlipDAO;
    #endregion


    [SetUp]
    public void Setup()
    {
        //Guid
        string developerGuid = Guid.NewGuid().ToString("N");
        //Insert own name.
        _developerID = new Guid().ToString("N") + "_Developer";
        //Data access for "HourSlip"
        _hourSlipDAO = new HourSlipDao(_connectionString);
    }

    #region Testcases

    [Test]
    public async Task CreateHourSlip()
    {
        //Arrange
        // Tests the creation of a new HourSlip.
        //HourSlip hourSlip = new HourSlip(184, DateTime.Today, 1, new DateTime(2023, 4, 30, 9, 0, 0), new DateTime(2023, 4, 30, 17, 0, 0));
        HourSlip hourSlip = new HourSlip();
        hourSlip.EmployeeId = 184;
        hourSlip.Date = DateTime.Today;
        hourSlip.StartTime = new DateTime(2023, 4, 30, 9, 0, 0);
        hourSlip.EndTime = new DateTime(2023, 4, 30, 17, 0, 0);
        Console.WriteLine(hourSlip.ProjectId);
        //Expected and Actual values
        int expectedHourslipID = default;
        //Act
        int actualHourSlipID = await _hourSlipDAO.AddAsync(hourSlip);
        expectedHourslipID = actualHourSlipID;
        //Assert
        Assert.That(expectedHourslipID, Is.EqualTo(actualHourSlipID), $"Should have the same id: actualID:{actualHourSlipID} expectedID{expectedHourslipID}");
    }

    [Test]
    public async Task GetHourSlipByEmployeeByID()
    {
        //Arrange
        IEnumerable<HourSlip> expectedhourSlips;
        //Act
        IEnumerable<HourSlip> actualhourSlips = await _hourSlipDAO.GetAllHourSlipsFromEmployeeAsync(1);
        expectedhourSlips = actualhourSlips;
        //Assert
        Assert.That(expectedhourSlips, Is.EquivalentTo(actualhourSlips), $"These lists should contain the same values: expectedCount {expectedhourSlips.Count()} actualCount{actualhourSlips.Count()}");
    }

    [Test]
    public async Task GetAllHourSlip()
    {
        //Arrange
        IEnumerable<HourSlip> expectedhourSlips = new List<HourSlip>() { new HourSlip(), new HourSlip() };
        IEnumerable<HourSlip> actualhourSlips = default!;
        //Act
        actualhourSlips = await _hourSlipDAO.GetAllAsync();
        //Assert
        Assert.That(expectedhourSlips, Is.EquivalentTo(actualhourSlips), $"These lists should contain the same values: expectedCount {expectedhourSlips.Count()} actualCount{actualhourSlips.Count()}");
    }

    [Test]
    public async Task GetAllUnapprovedHourSlips()
    {
        //Arrange
        IEnumerable<HourSlip> expectedhourSlips = new List<HourSlip>() { new HourSlip(), new HourSlip() };
        IEnumerable<HourSlip> actualhourSlips = default!;
        //Act
        actualhourSlips = await _hourSlipDAO.GetAllUnapprovedHourSlipsAsync();
        //Assert
        Assert.That(expectedhourSlips, Is.EquivalentTo(actualhourSlips), $"These lists should contain the same values: expectedCount {expectedhourSlips.Count()} actualCount{actualhourSlips.Count()}");

    }
    [Test]
    public void GetAllHourSlipsFromEmployeeById()
    {
        Console.WriteLine(_hourSlipDAO.GetAllHourSlipsFromEmployeeAsync(184));
        //Arrange
        //Act
        //Assert
    }

    public void DeleteHourSlipByUserID()
    {
        throw new NotImplementedException();
        //Arrange
        //Act
        //Assert
    }

    #endregion

    [TearDown]
    public void TearDown()
    {

    }

    #region Helper methods
    public void DeleteFromDatabase()
    {
        int rows;
        string delete = $"delete from HourSlip where employee_id = @id";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(delete, connection);

            cmd.Parameters.AddWithValue("@employee_id", _developerID);

            rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows);
        }
    }
    #endregion

}
