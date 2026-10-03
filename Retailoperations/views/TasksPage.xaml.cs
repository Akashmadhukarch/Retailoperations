using Retailoperations.models;
using Retailoperations.viewmodels;

namespace Retailoperations.views;

public partial class TasksPage : ContentPage
{
    public TasksPage()
        : this(null, isManager: true)
    {
    }

    public TasksPage(int? employeeId, bool isManager = true)
    {
        InitializeComponent();

        var createTaskButton = this.FindByName("CreateTaskButton") as Button;
        if (createTaskButton != null)
        {
            createTaskButton.IsVisible = isManager;
        }

        BindingContext = new TasksViewModel(employeeId);
    }

    private async void ViewTask_Clicked(
        object sender,
        EventArgs e)
    {
        if (sender is Button button &&
            button.BindingContext is TaskItem task)
        {
            await Shell.Current.Navigation.PushAsync(
                new TaskDetailsPage(task));
        }
    }

    private async void CreateTask_Clicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync("CreateTaskPage");
    }
}
