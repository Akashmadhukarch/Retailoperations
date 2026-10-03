using System.Collections.ObjectModel;
using Retailoperations.models;
using Retailoperations.services;

namespace Retailoperations.viewmodels;

public class EmployeesViewModel
{
    private readonly MockDataService _dataService;

    public ObservableCollection<Employee> Employees { get; }

    public EmployeesViewModel()
    {
        _dataService = new MockDataService();

        Employees = new ObservableCollection<Employee>(
            _dataService.GetEmployees());
    }
}