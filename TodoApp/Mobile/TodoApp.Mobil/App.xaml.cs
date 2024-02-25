using FmgLib.HttpClientHelper;
using TodoApp.Core.Enums;
using TodoApp.Core.Models;

namespace TodoApp.Mobil
{
    public partial class App : Application
    {
        public static string BaseUrl { get; private set; }
        public App()
        {
            BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5234/api" : "http://localhost:5234/api";
            GetThemeAsync();
            InitializeComponent();

            MainPage = new AppShell();
        }
        private async void GetThemeAsync()
        {
            var model = await HttpClientHelper.SendAsync<SettingsModel>($"{BaseUrl}/settings",HttpMethod.Get);
            UserAppTheme = model.Theme == TaskTheme.Dark ? AppTheme.Dark : AppTheme.Light;
        }
    }
}
