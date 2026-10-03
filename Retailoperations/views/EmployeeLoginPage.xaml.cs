using Retailoperations.viewmodels;

namespace Retailoperations.views;

public partial class EmployeeLoginPage : ContentPage
{
    public EmployeeLoginPage()
    {
        InitializeComponent();
        BindingContext = new EmployeeLoginViewModel();
    }
    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
