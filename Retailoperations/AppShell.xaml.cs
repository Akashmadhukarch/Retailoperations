namespace Retailoperations;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            "DashboardPage",
            typeof(views.DashboardPage));
        Routing.RegisterRoute(
           "TasksPage",
            typeof(views.TasksPage));
        Routing.RegisterRoute(
    "TasksPage",
    typeof(views.TasksPage));
        Routing.RegisterRoute(
    "TaskDetailsPage",
    typeof(views.TaskDetailsPage));
        Routing.RegisterRoute(
    "EmployeesPage",
    typeof(views.EmployeesPage));
        Routing.RegisterRoute(
    "CreateTaskPage",
    typeof(views.CreateTaskPage));

    }
}