using Retailoperations.viewmodels;

namespace Retailoperations.views;

public partial class EmployeesPage : ContentPage
{
    public EmployeesPage()
    {
        InitializeComponent();

        BindingContext = new EmployeesViewModel();
    }
}