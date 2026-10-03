using System.Collections.ObjectModel;
using System.Windows.Input;
using Retailoperations.models;
using Retailoperations.services;

namespace Retailoperations.viewmodels;

public class CreateTaskViewModel
{
    private readonly MockDataService _dataService;

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Priority { get; set; } = string.Empty;

    public DateTime DueDate { get; set; } = DateTime.Today;

    public ObservableCollection<string> Priorities { get; }

    public ObservableCollection<Employee> Employees { get; }

    public Employee? SelectedEmployee { get; set; }

    public ICommand CreateTaskCommand { get; }

    public CreateTaskViewModel()
    {
        _dataService = new MockDataService();

        Priorities = new ObservableCollection<string>
        {
            "Low",
            "Medium",
            "High"
        };

        Employees = new ObservableCollection<Employee>(
            _dataService.GetEmployees());

        CreateTaskCommand = new Command(CreateTask);
    }

    private async void CreateTask()
    {
        if (string.IsNullOrWhiteSpace(Title) ||
            string.IsNullOrWhiteSpace(Description) ||
            string.IsNullOrWhiteSpace(Priority) ||
            SelectedEmployee == null)
        {
            await Shell.Current.DisplayAlertAsync(
                "Error",
                "Please fill all task details.",
                "OK");

            return;
        }

        var newTask = new TaskItem
        {
            Id = _dataService.GetTasks().Count + 1,
            Title = Title,
            Description = Description,
            Priority = Priority,
            Status = "Pending",
            DueDate = DueDate,
            AssignedEmployeeId = SelectedEmployee.Id,
            AssignedEmployeeName = SelectedEmployee.Name
        };

        _dataService.AddTask(newTask);

        await Shell.Current.DisplayAlertAsync(
            "Success",
            "Task created successfully.",
            "OK");

        await Shell.Current.GoToAsync("TasksPage");
    }
}
