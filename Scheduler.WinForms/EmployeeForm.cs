using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;

namespace Scheduler.WinForms
{
    public partial class EmployeeForm : Form
    {
        private IEmployeeDao<EmployeeDto> _employeeDao;
        private List<EmployeeDto> _employeeList = new List<EmployeeDto>();

        public EmployeeForm(IEmployeeDao<EmployeeDto> employeeDao)
        {
            _employeeDao = employeeDao;
            InitializeComponent();
        }

        private async Task OpenCreatePanel()
        {
            CreateEmployeeForm createEmployeeForm = new CreateEmployeeForm(_employeeDao);
            createEmployeeForm.ShowDialog(this);
            createEmployeeForm.Dispose();
            await ReloadAll();
        }

        private async Task OpenDeletePanel()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result != DialogResult.OK)
            {
                return;
            }
            if (employeeListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                await _employeeDao.DeleteAsync(int.Parse(employeeIdTextBox.Text));
                MessageBox.Show("Employee successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            await ReloadAll();
        }

        private async void EmployeeForm_Load(object sender, EventArgs e)
        {
            await ReloadAll();
        }

        private async Task FillListAsync()
        {
            employeeListBox.Items.Clear();
            var employess = await _employeeDao.GetAllAsync();
            _employeeList = employess.ToList();
            foreach (var item in _employeeList)
            {
                employeeListBox.Items.Add(item.ToString());
            }
        }

        private void employeeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (employeeListBox.SelectedIndex > -1)
            {
                FillTextBoxesWithEmployeeData();
                EnableElements();
            }
        }

        private void FillTextBoxesWithEmployeeData()
        {
            var employee = _employeeList[employeeListBox.SelectedIndex];
            firstNameTextBox.Text = employee.FirstName;
            lastNameTextBox.Text = employee.LastName;
            emailTextBox.Text = employee.Email;
            employeeIdTextBox.Text = employee.EmployeeId.ToString();
            phoneNumberTextBox.Text = employee.PhoneNumber;
            roleComboBox.Text = employee.Role;
            streetNameTextBox.Text = employee.Address.StreetName;
            streetNumberTextBox.Text = employee.Address.StreetNumber.ToString();
            zipCodeTextBox.Text = employee.Address.ZipCode.ToString();
            cityTextBox.Text = employee.Address.City;
        }

        private async void createBtn_Click(object sender, EventArgs e)
        {
            await OpenCreatePanel();
        }

        private async void editBtn_Click(object sender, EventArgs e)
        {
            await EditEmployee();
        }

        private async Task EditEmployee()
        {
            if (!ValidateTextBoxes())
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var employeeToEdit = MapTextBoxesToEmployee();
            try
            {
                await _employeeDao.UpdateAsync(employeeToEdit);
                MessageBox.Show("Employee successfully edited", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured, be sure to fill all fields, and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            await ReloadAll();
        }

        private async Task ReloadAll()
        {
            await FillListAsync();
            ClearTextBoxes();
            DisableElements();
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            await OpenDeletePanel();
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
            employee.EmployeeId = int.Parse(employeeIdTextBox.Text);
            employee.Role = roleComboBox.Text;
            employee.Address = address;
            employee.Password = "";
            return employee;
        }

        private void EnableElements()
        {
            firstNameTextBox.Enabled = true;
            lastNameTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            phoneNumberTextBox.Enabled = true;
            roleComboBox.Enabled = true;
            streetNameTextBox.Enabled = true;
            streetNumberTextBox.Enabled = true;
            zipCodeTextBox.Enabled = true;
            cityTextBox.Enabled = true;
            createBtn.Enabled = true;
            editBtn.Enabled = true;
            deleteBtn.Enabled = true;
        }

        private void DisableElements()
        {
            firstNameTextBox.Enabled = false;
            lastNameTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            employeeIdTextBox.Enabled = false;
            phoneNumberTextBox.Enabled = false;
            roleComboBox.Enabled = false;
            streetNameTextBox.Enabled = false;
            streetNumberTextBox.Enabled = false;
            zipCodeTextBox.Enabled = false;
            cityTextBox.Enabled = false;
            editBtn.Enabled = false;
            deleteBtn.Enabled = false;
        }

        private void ClearTextBoxes()
        {
            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            employeeIdTextBox.Text = string.Empty;
            phoneNumberTextBox.Text = string.Empty;
            roleComboBox.Text = string.Empty;
            streetNameTextBox.Text = string.Empty;
            streetNumberTextBox.Text = string.Empty;
            zipCodeTextBox.Text = string.Empty;
            cityTextBox.Text = string.Empty;
        }
        private bool ValidateTextBoxes()
        {
            if (firstNameTextBox.Text == "" || lastNameTextBox.Text == "" || emailTextBox.Text == "" || phoneNumberTextBox.Text == "" || employeeIdTextBox.Text == ""
                || roleComboBox.Text == "" || streetNameTextBox.Text == "" || streetNumberTextBox.Text == "" || zipCodeTextBox.Text == "" || cityTextBox.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}