using Retailoperations.viewmodels;

namespace Retailoperations.views;

public partial class ManagerLoginPage : ContentPage
{
    public ManagerLoginPage()
    {
        InitializeComponent();
        BindingContext = new ManagerLoginViewModel();
    }
    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
