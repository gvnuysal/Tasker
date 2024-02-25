using TodoApp.Mobil.Views;

namespace TodoApp.Mobil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(DeletedTasksPage), typeof(DeletedTasksPage));
            Routing.RegisterRoute(nameof(DetailTaskPage), typeof(DetailTaskPage));
            Routing.RegisterRoute(nameof(FavouriteTaskPage), typeof(FavouriteTaskPage));
            Routing.RegisterRoute(nameof(ListTaskPage), typeof(ListTaskPage));
            Routing.RegisterRoute(nameof(ListTaskWithStatusPage), typeof(ListTaskWithStatusPage));
            Routing.RegisterRoute(nameof(AddTaskPage), typeof(AddTaskPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        }
    }
}
