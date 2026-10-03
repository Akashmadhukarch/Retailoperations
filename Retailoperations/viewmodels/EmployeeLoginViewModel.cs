using System;
using System.Linq;
using System.Windows.Input;
using Retailoperations.services;
using Retailoperations.views;

namespace Retailoperations.viewmodels;

public class EmployeeLoginViewModel
{
    public string Email { get; set; } = string.Empty;

    public ICommand LoginCommand { get; }

    public EmployeeLoginViewModel()
    {
        LoginCommand = new Command(Login);
    }

    private async void Login()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            await Shell.Current.DisplayAlertAsync(
                "Error",
                "Please enter your email.",
                "OK");

            return;
        }

        // Find employee by email
        var dataService = new MockDataService();
        var employee = dataService.GetEmployees()
            .FirstOrDefault(e => e.Email.Equals(Email, StringComparison.OrdinalIgnoreCase));

        if (employee != null)
        {
            // Navigate to employee tasks page (filtered to this employee)
            // Pass employeeId and isManager=false
            await Shell.Current.Navigation.PushAsync(
                new TasksPage(employee.Id, isManager: false));
            return;
        }

        await Shell.Current.DisplayAlertAsync(
            "Error",
            "Employee not found. Please check your email.",
            "OK");
    }
}
