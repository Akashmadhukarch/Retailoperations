using Retailoperations.models;

namespace Retailoperations.views;

public partial class TaskDetailsPage : ContentPage
{
    private readonly TaskItem _task;

    public TaskDetailsPage(TaskItem task)
    {
        InitializeComponent();

        _task = task;
        BindingContext = _task;
    }

    private async void BackButton_Clicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}