using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
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
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
