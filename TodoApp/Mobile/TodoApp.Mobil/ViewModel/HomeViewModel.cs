using CommunityToolkit.Mvvm.ComponentModel;
using FmgLib.HttpClientHelper;
using System.Reflection.Metadata.Ecma335;
using TodoApp.Core.Models;
using TodoApp.Mobil.ViewModel.Common;

namespace TodoApp.Mobil.ViewModel;

public partial class HomeViewModel:BaseViewModel
{
    [ObservableProperty]
    private SettingsModel _settings;

    [ObservableProperty]
    private List<TaskModel> _tasks;

    [ObservableProperty]
    private string _userText;

    public HomeViewModel()
    {
        GetHomePageDetailAsync();
    }
    private async void GetHomePageDetailAsync()
    {
        Tasks = await HttpClientHelper.SendAsync<List<TaskModel>>($"{App.BaseUrl}/task/get-all-today", HttpMethod.Get);
        Settings= await HttpClientHelper.SendAsync<SettingsModel>($"{App.BaseUrl}/settings", HttpMethod.Get);
        UserText=GetUserText();

    }
    private string GetUserText()
    {
        var time=DateTime.Now.Hour;
        if(time>=5 && time < 12)
        {
            return $"Good Morning,{Settings.UserName}";
        }
        else if(time>=12 && time < 18)
        {
            return $"Good Afternoon,{Settings.UserName}";
        }
        else
        {
            return $"Good Night,{Settings.UserName}";
        }
    }
}
