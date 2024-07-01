using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;

namespace Scheduler.WinForms
{
    public partial class LoginForm : Form
    {
        private IEmployeeDao<EmployeeDto> _employeeDao;
        public LoginForm(IEmployeeDao<EmployeeDto> employeeDao)
        {
            _employeeDao = employeeDao;
            InitializeComponent();
        }

        private async void loginLbl_Click(object sender, EventArgs e)
        {
            await Login();
        }

        private async Task Login()
        {
            loginBtn.Enabled = false;
            EmployeeDto? employeeDto = null;
            try
            {
                employeeDto = await _employeeDao.LoginAsync(emailTextBox.Text, passwordTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured, or invalid credentials \ntry again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loginBtn.Enabled = true;
                return;

            }
            if (employeeDto == null)
            {
                MessageBox.Show("Invalid email or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loginBtn.Enabled = true;
                return;
            }
            if (employeeDto.Role != "Admin")
            {
                MessageBox.Show("You do not have authorization for this app", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loginBtn.Enabled = true;
                return;
            }
            this.Hide();
            EmployeeForm employeeForm = new EmployeeForm(_employeeDao);
            employeeForm.ShowDialog();


        }
    }
}
