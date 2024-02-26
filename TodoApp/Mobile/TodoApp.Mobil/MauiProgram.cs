using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TodoApp.Mobil.ViewModel;
using TodoApp.Mobil.Views;

namespace TodoApp.Mobil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<AddTaskPage>();
            builder.Services.AddTransient<DeletedTasksPage>();
            builder.Services.AddTransient<DetailTaskPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<ListTaskPage>();
            builder.Services.AddTransient<ListTaskWithStatusPage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<FavouriteTaskPage>();

            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<AddTaskViewModel>();
            builder.Services.AddTransient<DeletedViewModel>();
            builder.Services.AddTransient<DetailTaskViewModel>();
            builder.Services.AddTransient<FavouriteViewModel>();
            builder.Services.AddTransient<ListTaskViewModel>();
            builder.Services.AddTransient<ListTaskWithStatusViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
