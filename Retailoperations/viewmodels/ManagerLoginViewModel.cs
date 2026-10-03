using System;
using System.Windows.Input;
using Retailoperations.views;

namespace Retailoperations.viewmodels;

public class ManagerLoginViewModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public ICommand LoginCommand { get; }

    public ManagerLoginViewModel()
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

        // Manager credentials check
        if (Email.Equals("manager@store.com", StringComparison.OrdinalIgnoreCase) &&
            Password == "manager")
        {
            // Navigate to manager dashboard (all tasks visible)
            await Shell.Current.GoToAsync("DashboardPage");
            return;
        }

        await Shell.Current.DisplayAlertAsync(
            "Error",
            "Invalid manager credentials.",
            "OK");
    }
}
