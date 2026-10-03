namespace Retailoperations.views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void ManagerLogin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///ManagerLoginPage");
    }

    private async void EmployeeLogin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///EmployeeLoginPage");
    }
}