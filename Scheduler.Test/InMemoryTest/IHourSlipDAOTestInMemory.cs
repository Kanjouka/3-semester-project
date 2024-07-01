using Scheduler.Dal.InMemoryDAO;
using Scheduler.Interfaces;
using Scheduler.Model;

namespace Scheduler.Test.InMemoryTest;

public class IHourSlipDAOTestInMemory
{
    private IHourSlipDaoAsync<HourSlip> _hourSlipDAO;

    [SetUp]
    public void Setup()
    {
        _hourSlipDAO = new InMemoryHourSlipDAO();
    }

    [Test]
    public async Task CreateHourSlipMethodTest()
    {
        //Arrange
        var hourSlip = new HourSlip()
        {
            Id = 100,
            Date = DateTime.Now,
            IsApproved = false,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(5),
        };
        //Act
        var hourSlipId = await _hourSlipDAO.AddAsync(hourSlip);
        //Assert
        Assert.True(hourSlip.Id == hourSlipId);
    }

    [Test]
    public async Task GetHourSlipByIdMethodTest()
    {
        var hourSlip = await _hourSlipDAO.GetByIdAsync(3);
        //Assert
        Assert.True(hourSlip.Id == 3);
    }

    [Test]
    public async Task GetAllHourSlipsFromEmployeeMethodTest()
    {
        //Arrange
        var hourSlip = new HourSlip()
        {
            Id = 100,
            Date = DateTime.Now,
            IsApproved = false,
        };
        //Act
        await _hourSlipDAO.AddAsync(hourSlip);
        var hourSlips = await _hourSlipDAO.GetAllHourSlipsFromEmployeeAsync(1);
        //Assert
        Assert.True(hourSlips.Count() == 1);
    }

    [Test]
    public async Task GetAllUnApprovedHourSlipsFromEmployeeMethodTest()
    {
        //Arrange
        var hourSlip = new HourSlip()
        {
            EmployeeId = 100,
            Id = 1,
            Date = DateTime.Now,
            IsApproved = false,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(5),
        };
        var hourSlip1 = new HourSlip()
        {
            EmployeeId = 100,
            Id = 2,
            Date = DateTime.Now,
            IsApproved = false,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(5),
        };
        //Act
        await _hourSlipDAO.AddAsync(hourSlip);
        await _hourSlipDAO.AddAsync(hourSlip1);
        var hourSlips = await _hourSlipDAO.GetAllHourSlipsFromEmployeeAsync(100);
        //Assert
        Assert.True(hourSlips.Count() == 2);
    }

    [Test]
    public async Task UpdateHourSlipMethodTest()
    {
        //Arrange
        var hourSlipToBeUpdatede = await _hourSlipDAO.GetByIdAsync(1);
        hourSlipToBeUpdatede.IsApproved = true;
        //Act
        await _hourSlipDAO.UpdateAsync(hourSlipToBeUpdatede);
        var updatedHourSlip = await _hourSlipDAO.GetByIdAsync(1);
        //Assert
        Assert.True(updatedHourSlip.IsApproved == true);
    }

    [Test]
    public async Task DeleteHourSlipMethodTest()
    {
        //Arrange
        var hourSlipToBeDeleted = await _hourSlipDAO.GetByIdAsync(1);
        if (hourSlipToBeDeleted == null) Assert.Fail();
        //Act
        await _hourSlipDAO.DeleteAsync(hourSlipToBeDeleted.Id);
        var deletedHourSlip = await _hourSlipDAO.GetByIdAsync(1);
        //Assert
        Assert.True(deletedHourSlip == null);
    }

    [Test]
    public async Task GetAllUnApprovedHourSlipsMethodTest()
    {
        //Act
        IEnumerable<HourSlip> unApprovedHourSlips = await _hourSlipDAO.GetAllUnapprovedHourSlipsAsync();
        int countUnApprovedHourSlips = unApprovedHourSlips.Count();
        //Assert
        Assert.True(countUnApprovedHourSlips == 10);
    }
}