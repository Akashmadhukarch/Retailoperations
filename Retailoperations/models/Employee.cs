using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Retailoperations.models;

public class Employee : INotifyPropertyChanged
{
    private string _name = string.Empty;
    private string _role = string.Empty;
    private string _email = string.Empty;
    private string _phone = string.Empty;
    private string _status = string.Empty;

    public int Id { get; set; }

    public string Name
    {
        get => _name;
        set
        {
            if (_name == value)
                return;

            _name = value;
            OnPropertyChanged();
        }
    }

    public string Role
    {
        get => _role;
        set
        {
            if (_role == value)
                return;

            _role = value;
            OnPropertyChanged();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (_email == value)
                return;

            _email = value;
            OnPropertyChanged();
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            if (_phone == value)
                return;

            _phone = value;
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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}