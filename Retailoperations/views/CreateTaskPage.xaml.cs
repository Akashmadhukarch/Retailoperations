using Retailoperations.viewmodels;

namespace Retailoperations.views;

public partial class CreateTaskPage : ContentPage
{
    public CreateTaskPage()
    {
        InitializeComponent();

        BindingContext = new CreateTaskViewModel();
    }
}