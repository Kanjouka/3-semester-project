using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;

namespace Scheduler.WinForms
{
    public partial class CreateEmployeeForm : Form
    {
        private IEmployeeDao<EmployeeDto> _employeeDao;

        public CreateEmployeeForm(IEmployeeDao<EmployeeDto> employeeDao)
        {
            InitializeComponent();
            _employeeDao = employeeDao;
        }

        private async void createBtn_Click(object sender, EventArgs e)
        {
            await CreateEmployee();
        }

        private async Task CreateEmployee()
        {
            EmployeeDto employee = MapTextBoxesToEmployee();
            if (!ValidateTextBoxes())
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                await _employeeDao.AddAsync(employee);
                MessageBox.Show("Employee created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured, try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private EmployeeDto MapTextBoxesToEmployee()
        {
            AddressDto address = new AddressDto();
            address.StreetName = streetNameTextBox.Text;
            address.City = cityTextBox.Text;
            address.StreetNumber = streetNumberTextBox.Text;
            address.ZipCode = zipCodeTextBox.Text;

            EmployeeDto employee = new EmployeeDto();
            employee.FirstName = firstNameTextBox.Text;
            employee.LastName = lastNameTextBox.Text;
            employee.Email = emailTextBox.Text;
            employee.PhoneNumber = phoneNumberTextBox.Text;
            employee.Password = passwordTextBox.Text;
            employee.Role = roleComboBox.Text;
            employee.Address = address;
            return employee;
        }

        private bool ValidateTextBoxes()
        {
            if (firstNameTextBox.Text == "" || lastNameTextBox.Text == "" ||
                emailTextBox.Text == "" || phoneNumberTextBox.Text == "" ||
                passwordTextBox.Text == "" || roleComboBox.Text == "" ||
                streetNameTextBox.Text == "" || streetNumberTextBox.Text == "" ||
                zipCodeTextBox.Text == "" || cityTextBox.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}