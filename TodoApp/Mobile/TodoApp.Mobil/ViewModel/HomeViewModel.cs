using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FmgLib.HttpClientHelper;
using TodoApp.Core.Models;
using TodoApp.Mobil.ViewModel.Common;

namespace TodoApp.Mobil.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    [ObservableProperty]
    private SettingsModel _settings;

    [ObservableProperty]
    private List<TaskModel> _tasks;

    [ObservableProperty]
    private string _userText;

    [ObservableProperty]
    private string _thisMonthTaskCount;
    public HomeViewModel()
    {
        GetHomePageDetailAsync();
    }

    [RelayCommand]
    public async Task GotoStatusPage(string status)
    {
        ListTaskWithStatusViewModel.StatusValue=int.Parse(status);
        await Shell.Current.GoToAsync(nameof(ListTaskWithStatusViewModel));
    }

    [RelayCommand]
    public async Task Search(string searchText)
    {
        var tasks = await HttpClientHelper.SendAsync<List<TaskModel>>($"{App.BaseUrl}/task/get-all-search/{searchText}",HttpMethod.Get);
    }
    private async Task GetHomePageDetailAsync()
    {
        Tasks = await HttpClientHelper.SendAsync<List<TaskModel>>(serviceUrl: $"{App.BaseUrl}/task/get-all-today", method: HttpMethod.Get);
        Settings = await HttpClientHelper.SendAsync<SettingsModel>($"{App.BaseUrl}/settings", HttpMethod.Get);
        UserText = GetUserText();
        ThisMonthTaskCount = await GetThisMonthTasksCountAsync();
    }
    private async Task<string> GetThisMonthTasksCountAsync()
    {
        var count = await HttpClientHelper.SendAsync<string>($"{App.BaseUrl}/task/get-all-this-month-task-count",HttpMethod.Get);
         
        if(string .IsNullOrEmpty(count))
        {
            return $"You have {count} tasks this month";
        }
        return $"You have {count} tasks this month";
    }
    private string GetUserText()
    {
        var time = DateTime.Now.Hour;
        if (time >= 5 && time < 12)
        {
            return $"Good Morning,{Settings.UserName}";
        }
        else if (time >= 12 && time < 18)
        {
            return $"Good Afternoon,{Settings.UserName}";
        }
        else
        {
            return $"Good Night,{Settings.UserName}";
        }
    }
}
