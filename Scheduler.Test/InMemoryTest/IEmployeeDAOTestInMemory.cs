using Scheduler.Dal.InMemoryDAO;
using Scheduler.Interfaces;
using Scheduler.Model;

namespace Scheduler.Test.InMemoryTest
{
    public class IEmployeeDAOTestInMemory
    {
        private IEmployeeDao<Employee> _employeeDAO;
        [SetUp]
        public void Setup()
        {

            _employeeDAO = new InMemoryEmployeeDAO();
        }

        [Test]
        public async Task CreateEmployeeMethodTest()
        {
            //Arrange

            var employee = new Employee()
            {
                EmployeeId = 100,
                FirstName = "Bob",
                LastName = "Bobsen",

            };

            //Act

            var employeeId = await _employeeDAO.AddAsync(employee);
            //Assert
            Assert.True(employee.EmployeeId == employeeId);

        }

        [Test]
        public async Task GetEmployeeByIdMethodTest()
        {
            //Arrange
            var employee = new Employee()
            {
                EmployeeId = 100,
                FirstName = "Bob",
                LastName = "Bobsen",

            };
            //Act
            var employeeId = await _employeeDAO.AddAsync(employee);
            var foundEmployee = await _employeeDAO.GetByIdAsync(employeeId);
            //Assert
            Assert.True(foundEmployee == employee);

        }
        [Test]
        public async Task GetAllEmployeeMethodTest()
        {
            //Arrange
            //Act
            var employees = await _employeeDAO.GetAllAsync();
            //Assert
            Assert.True(employees.Count() == 10); //The InMemoryDAO is currently hardcoded to 10 employees. 

        }
        [Test]
        public async Task DeleteEmployeeMethodTest()
        {
            //Arrange
            var employee = new Employee()
            {
                EmployeeId = 100,
                FirstName = "Bob",
                LastName = "Bobsen"
            };
            //Act
            var employeeId = await _employeeDAO.AddAsync(employee);
            await _employeeDAO.DeleteAsync(employeeId);
            var foundEmployee = await _employeeDAO.GetByIdAsync(employeeId);
            //Assert
            Assert.True(foundEmployee == null);
        }
        [Test]
        public async Task UpdateEmplyeeMethodTest()
        {
            //Arrange
            var employee = new Employee()
            {
                EmployeeId = 100,
                FirstName = "Bob",
                LastName = "Bobsen"
            };
            //Act
            var employeeId = await _employeeDAO.AddAsync(employee);
            employee.FirstName = "Bobby";
            await _employeeDAO.UpdateAsync(employee);
            var foundEmployee = await _employeeDAO.GetByIdAsync(employeeId);
            //Assert
            Assert.True(foundEmployee.FirstName == "Bobby");
        }
    }

}