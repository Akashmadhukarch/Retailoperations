using System.Collections.ObjectModel;
using System.Linq;
using Retailoperations.models;
using Retailoperations.services;

namespace Retailoperations.viewmodels;

public class TasksViewModel
{
    private readonly MockDataService _dataService;

    public ObservableCollection<TaskItem> Tasks { get; }

    // If employeeId is provided, show only tasks assigned to that employee
    public TasksViewModel(int? employeeId = null)
    {
        _dataService = new MockDataService();

        var tasks = _dataService.GetTasks().AsEnumerable();

        if (employeeId.HasValue)
        {
            tasks = tasks.Where(t => t.AssignedEmployeeId == employeeId.Value);
        }

        Tasks = new ObservableCollection<TaskItem>(tasks);
    }
}
