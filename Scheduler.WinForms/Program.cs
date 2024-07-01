using Scheduler.ApiClient;

namespace Scheduler.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            //var apiClient = new EmployeeApiClient("https://scheduler.nu/api");
            var apiClient = new EmployeeApiClient("https://localhost:7114");
            Application.Run(new LoginForm(apiClient));
        }
    }
}