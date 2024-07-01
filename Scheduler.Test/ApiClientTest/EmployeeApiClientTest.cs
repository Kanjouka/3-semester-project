using RestSharp;
using Scheduler.ApiClient;
using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;
using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Test.ApiClientTest;

public class EmployeeApiClientTest
{
    private IEmployeeDao<EmployeeDto> _EmployeeApiClient;
    private EmployeeDto _TestEmployee;

    [SetUp]
    public void Setup()
    {
        _EmployeeApiClient = new EmployeeApiClient("https://localhost:7114/api");
        //_EmployeeApiClient = new EmployeeApiClient("https://scheduler.nu/api/api");
        _TestEmployee = new EmployeeDto
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test21@test21.dk",
            PhoneNumber = "234234234",
            Password = "testtesttest",
            Role = "Employee",
            Address = new AddressDto
            {
                StreetName = "Test",
                StreetNumber = "Test",
                ZipCode = "9560",
                City = "Hadsund"
            }
        };
    }

    [TearDown]
    public void Cleanup()
    {
        // Clean up the test data
        if (_TestEmployee.EmployeeId > 0)
        {
            _EmployeeApiClient.DeleteAsync(_TestEmployee.EmployeeId);
        }
    }

    [Test]
    public async Task AddAsyncShouldCreateNewEmployee()
    {
        //Arrange

        //Act
        _TestEmployee.EmployeeId = await _EmployeeApiClient.AddAsync(_TestEmployee);
        //Assert
        Assert.That(_TestEmployee.EmployeeId, Is.GreaterThan(0));
    }

    [Test]
    public async Task DeleteAsyncShouldDeleteEmployee()
    {
        //Arrange
        _TestEmployee.EmployeeId = await _EmployeeApiClient.AddAsync(_TestEmployee);
        //Act
        bool success = await _EmployeeApiClient.DeleteAsync(_TestEmployee.EmployeeId);
        //Assert
        Assert.IsTrue(success);
    }

    [Test]
    public async Task GetAllAsyncShouldReturnListOfEmployees()
    {
        // Arrange

        // Act
        var employees = await _EmployeeApiClient.GetAllAsync();

        // Assert
        Assert.That(employees, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task GetByIdAsyncShouldReturnEmployee()
    {
        // Arrange
        _TestEmployee.EmployeeId = await _EmployeeApiClient.AddAsync(_TestEmployee);

        //Act
        var employee = await _EmployeeApiClient.GetByIdAsync(_TestEmployee.EmployeeId);

        //Assert
        Assert.That(employee, Is.Not.Null);
    }

    [Test]
    public async Task LoginAsyncShouldReturnEmployee()
    {
        // Arrange
        _TestEmployee.EmployeeId = await _EmployeeApiClient.AddAsync(_TestEmployee);
        var email = _TestEmployee.Email;
        var password = _TestEmployee.Password;

        // Act
        var employee = await _EmployeeApiClient.LoginAsync(email, password);

        // Assert
        Assert.That(employee, Is.Not.Null);
    }
}