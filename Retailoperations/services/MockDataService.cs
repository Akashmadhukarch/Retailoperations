using System.Text.Json;
using Retailoperations.models;

namespace Retailoperations.services;

public class MockDataService
{
    private static readonly List<TaskItem> _tasks = new();
    private static bool _initialized = false;
    private const string TasksStorageKey = "retail_tasks_storage";

    // Employee data
    private static readonly List<Employee> _employees = new()
    {
        new Employee
        {
            Id = 1,
            Name = "Rahul Kumar",
            Role = "Sales Associate",
            Email = "rahul@store.com",
            Phone = "9876543210",
            Status = "Active"
        },
        new Employee
        {
            Id = 2,
            Name = "Priya Sharma",
            Role = "Inventory Associate",
            Email = "priya@store.com",
            Phone = "9876543211",
            Status = "Active"
        },
        new Employee
        {
            Id = 3,
            Name = "Arjun Reddy",
            Role = "Store Associate",
            Email = "arjun@store.com",
            Phone = "9876543212",
            Status = "Inactive"
        }
    };

    public MockDataService()
    {
        if (!_initialized)
        {
            LoadTasksFromStorage();
            _initialized = true;
        }
    }

    private void LoadTasksFromStorage()
    {
        try
        {
            string? tasksJson = Preferences.Default.Get<string>(TasksStorageKey, null);

            if (!string.IsNullOrEmpty(tasksJson))
            {
                var savedTasks = JsonSerializer.Deserialize<List<TaskItem>>(tasksJson);
                if (savedTasks != null && savedTasks.Count > 0)
                {
                    _tasks.Clear();
                    _tasks.AddRange(savedTasks);
                    return;
                }
            }
        }
        catch { }

        // Load default tasks if no saved data exists
        LoadDefaultTasks();
    }

    private void LoadDefaultTasks()
    {
        if (_tasks.Count > 0) return;

        _tasks.AddRange(new List<TaskItem>
        {
            new TaskItem
            {
                Id = 1,
                Title = "Restock Beverage Section",
                Description = "Restock Coca-Cola, Pepsi, Sprite, Fanta, and packaged drinking water. Check the shelf quantity and refill products that are below the minimum stock level.",
                Priority = "High",
                Status = "Pending",
                DueDate = DateTime.Today.AddHours(11),
                AssignedEmployeeId = 1,
                AssignedEmployeeName = "Rahul Kumar"
            },
            new TaskItem
            {
                Id = 2,
                Title = "Check Price Labels",
                Description = "Verify the price labels for Samsung TVs, LG refrigerators, Whirlpool washing machines, and other electronics. Make sure the displayed prices match the system prices.",
                Priority = "Medium",
                Status = "In Progress",
                DueDate = DateTime.Today.AddHours(14),
                AssignedEmployeeId = 2,
                AssignedEmployeeName = "Priya Sharma"
            },
            new TaskItem
            {
                Id = 3,
                Title = "Clean Storage Area",
                Description = "Clean and organize the back storage area. Arrange cartons of rice, cooking oil, cleaning products, and household supplies in their designated locations.",
                Priority = "Low",
                Status = "Completed",
                DueDate = DateTime.Today.AddHours(16),
                AssignedEmployeeId = 3,
                AssignedEmployeeName = "Arjun Reddy"
            },
            new TaskItem
            {
                Id = 4,
                Title = "Inventory Count",
                Description = "Perform a physical inventory count of laptops, monitors, keyboards, mice, and other computer accessories. Record the available quantity and identify any stock differences.",
                Priority = "High",
                Status = "Pending",
                DueDate = DateTime.Today.AddHours(17),
                AssignedEmployeeId = 1,
                AssignedEmployeeName = "Rahul Kumar"
            }
        });

        SaveTasksToStorage();
    }

    private void SaveTasksToStorage()
    {
        try
        {
            string tasksJson = JsonSerializer.Serialize(_tasks);
            Preferences.Default.Set(TasksStorageKey, tasksJson);
        }
        catch { }
    }

    public List<TaskItem> GetTasks()
    {
        return _tasks;
    }

    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
        SaveTasksToStorage();
    }

    public List<Employee> GetEmployees()
    {
        return _employees;
    }
}