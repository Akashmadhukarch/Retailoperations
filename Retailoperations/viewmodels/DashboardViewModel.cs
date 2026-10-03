using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Retailoperations.models;
using Retailoperations.services;

namespace Retailoperations.viewmodels;

public class DashboardViewModel : INotifyPropertyChanged
{
    private readonly MockDataService _dataService;

    public ObservableCollection<TaskItem> RecentTasks { get; }

    public int PendingTasks =>
        RecentTasks.Count(t => t.Status == "Pending");

    public int CompletedTasks =>
        RecentTasks.Count(t => t.Status == "Completed");

    public int InProgressTasks =>
        RecentTasks.Count(t => t.Status == "In Progress");

    public int Employees =>
        _dataService.GetEmployees().Count;

    public int OpenIssues { get; } = 3;

    public ICommand ViewTasksCommand { get; }

    public ICommand ViewEmployeesCommand { get; }

    public DashboardViewModel()
    {
        _dataService = new MockDataService();

        RecentTasks = new ObservableCollection<TaskItem>(
            _dataService.GetTasks());

        ViewTasksCommand = new Command(ViewTasks);

        ViewEmployeesCommand = new Command(ViewEmployees);

        foreach (var task in RecentTasks)
        {
            task.PropertyChanged += Task_PropertyChanged;
        }
    }

    private void Task_PropertyChanged(
        object? sender,
        PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TaskItem.Status))
        {
            OnPropertyChanged(nameof(PendingTasks));
            OnPropertyChanged(nameof(CompletedTasks));
            OnPropertyChanged(nameof(InProgressTasks));
        }
    }

    private async void ViewTasks()
    {
        await Shell.Current.GoToAsync("TasksPage");
    }

    private async void ViewEmployees()
    {
        await Shell.Current.GoToAsync("EmployeesPage");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}