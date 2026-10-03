using Retailoperations.viewmodels;

namespace Retailoperations.views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
        BindingContext = new DashboardViewModel();
    }
}