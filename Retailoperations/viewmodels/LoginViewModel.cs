using System;
using System.Linq;
using System.Windows.Input;
using Retailoperations.services;
using Retailoperations.views;

namespace Retailoperations.viewmodels;

public class LoginViewModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new Command(Login);
    }

    private async void Login()
    {
        if (string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlertAsync(
                "Error",
                "Please enter email and password.",
                "OK");

            return;
        }

        // Simple role check: manager uses hard-coded credentials
        if (Email.Equals("manager@store.com", StringComparison.OrdinalIgnoreCase) &&
            Password == "manager")
        {
            // Navigate to manager dashboard
            await Shell.Current.GoToAsync("DashboardPage");
            return;
        }

        // Otherwise try to find an employee by email and navigate to Tasks page
        var dataService = new MockDataService();
        var employee = dataService.GetEmployees()
            .FirstOrDefault(e => e.Email.Equals(Email, StringComparison.OrdinalIgnoreCase));

        if (employee != null)
        {
            // Open TasksPage filtered to this employee
            await Shell.Current.Navigation.PushAsync(new TasksPage(employee.Id));
            return;
        }

        await Shell.Current.DisplayAlertAsync(
            "Error",
            "Invalid credentials or user not found.",
            "OK");
    }
}