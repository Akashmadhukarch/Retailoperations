using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Retailoperations.models;

public class TaskItem : INotifyPropertyChanged
{
    private string _title = string.Empty;
    private string _description = string.Empty;
    private string _priority = string.Empty;
    private string _status = string.Empty;
    private DateTime _dueDate;
    private int _assignedEmployeeId;
    private string _assignedEmployeeName = string.Empty;

    public int Id { get; set; }

    public string Title
    {
        get => _title;
        set
        {
            if (_title == value)
                return;

            _title = value;
            OnPropertyChanged();
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            if (_description == value)
                return;

            _description = value;
            OnPropertyChanged();
        }
    }

    public string Priority
    {
        get => _priority;
        set
        {
            if (_priority == value)
                return;

            _priority = value;
            OnPropertyChanged();
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            if (_status == value)
                return;

            _status = value;
            OnPropertyChanged();
        }
    }

    public DateTime DueDate
    {
        get => _dueDate;
        set
        {
            if (_dueDate == value)
                return;

            _dueDate = value;
            OnPropertyChanged();
        }
    }

    public int AssignedEmployeeId
    {
        get => _assignedEmployeeId;
        set
        {
            if (_assignedEmployeeId == value)
                return;

            _assignedEmployeeId = value;
            OnPropertyChanged();
        }
    }

    public string AssignedEmployeeName
    {
        get => _assignedEmployeeName;
        set
        {
            if (_assignedEmployeeName == value)
                return;

            _assignedEmployeeName = value;
            OnPropertyChanged();
        }
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