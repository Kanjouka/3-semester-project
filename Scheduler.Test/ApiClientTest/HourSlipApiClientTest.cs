using RestSharp;
using Scheduler.ApiClient;
using Scheduler.ApiClient.Dto;
using Scheduler.Dal;
using Scheduler.Interfaces;
using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Test.ApiClientTest;

[TestFixture]
public class HourSlipApiClientTest
{
    private IHourSlipDaoAsync<HourSlipDto> _HourSlipApiClient;
    private HourSlipDto _TestHourSlip;
    private IEmployeeDao<EmployeeDto> _EmployeeApiClient;
    private EmployeeDto _TestEmployee;

    [SetUp]
    public void Setup()
    {
        _HourSlipApiClient = new HourSlipApiClient("https://localhost:7114/api");
        //_EmployeeApiClient = new EmployeeApiClient("https://scheduler.nu/api/api");
        _EmployeeApiClient = new EmployeeApiClient("https://localhost:7114/api");
        //_EmployeeApiClient = new EmployeeApiClient("https://scheduler.nu/api/api");
        _TestEmployee = new EmployeeDto
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test21@test21.dk",
            PhoneNumber = "234234234",
            Password = "testtesttest",
            Role = "Manager",
            Address = new AddressDto
            {
                StreetName = "Test",
                StreetNumber = "1",
                ZipCode = "9560",
                City = "Hadsund"
            }
        };
        _TestHourSlip = new HourSlipDto
        {
            EmployeeId = 0,
            Date = DateTime.Now,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(8),
            IsApproved = false,
            ProjectId = 1
        };
    }

    [Test]
    public async Task AddAsync_ValidHourSlip_ReturnsValidId()
    {
        //Arrange
        _TestEmployee.EmployeeId = await _EmployeeApiClient.AddAsync(_TestEmployee);
        _TestHourSlip.EmployeeId = _TestEmployee.EmployeeId;
        //Act
        _TestHourSlip.Id = await _HourSlipApiClient.AddAsync(_TestHourSlip);

        //Assert
        Assert.IsTrue(_TestHourSlip.Id > 0);
    }

    [Test]
    public async Task DeleteAsyncShouldDeleteHourSlip()
    {
        //Arrange
        _TestEmployee.EmployeeId = await _EmployeeApiClient.AddAsync(_TestEmployee);
        _TestHourSlip.EmployeeId = _TestEmployee.EmployeeId;
        int hourslipId = await _HourSlipApiClient.AddAsync(_TestHourSlip);
        //Act
        bool success = await _HourSlipApiClient.DeleteAsync(hourslipId);
        //Assert
        Assert.IsTrue(success);
    }

    [Test]
    public async Task GetAllAsyncShouldReturnListOfHourSlips()
    {
        // Arrange
        _TestEmployee.EmployeeId = await _EmployeeApiClient.AddAsync(_TestEmployee);
        _TestHourSlip.EmployeeId = _TestEmployee.EmployeeId;
        _TestHourSlip.Id = await _HourSlipApiClient.AddAsync(_TestHourSlip);
        // Act
        var hourSlips = await _HourSlipApiClient.GetAllAsync();

        // Assert
        Assert.That(hourSlips, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task GetByIdAsyncShouldReturnHourSlip()
    {
        // Arrange
        _TestEmployee.EmployeeId = await _EmployeeApiClient.AddAsync(_TestEmployee);
        _TestHourSlip.EmployeeId = _TestEmployee.EmployeeId;
        _TestHourSlip.Id = await _HourSlipApiClient.AddAsync(_TestHourSlip);
        //Act
        var hourSlip = await _HourSlipApiClient.GetByIdAsync(_TestHourSlip.Id);

        //Assert
        Assert.That(hourSlip, Is.Not.Null);
    }

    [Test]
    public async Task ApproveHourSlipShouldReturnTrue()
    {
        //Arrange
        _TestEmployee.EmployeeId = await _EmployeeApiClient.AddAsync(_TestEmployee);
        _TestHourSlip.EmployeeId = _TestEmployee.EmployeeId;
        _TestHourSlip.Id = await _HourSlipApiClient.AddAsync(_TestHourSlip);

        //Act
        var hourSlipWithRowVersion = await _HourSlipApiClient.GetByIdAsync(_TestHourSlip.Id);
        bool success = await _HourSlipApiClient.ApproveHourSlip(hourSlipWithRowVersion);

        //Assert
        Assert.IsTrue(success);
    }

    [TearDown]
    public void Cleanup()
    {
        _HourSlipApiClient.DeleteAsync(_TestHourSlip.Id);
        _EmployeeApiClient.DeleteAsync(_TestEmployee.EmployeeId);
    }
}