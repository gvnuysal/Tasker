using CommunityToolkit.Mvvm.ComponentModel;
using TodoApp.Mobil.ViewModel.Common;

namespace TodoApp.Mobil.ViewModel;

public partial class AddTaskViewModel:BaseViewModel
{
    [ObservableProperty]
    private string _title;
    [ObservableProperty]
    private string _description;
    [ObservableProperty]
    private DateTime _date;
    [ObservableProperty]
    private TimeSpan _time;
    [ObservableProperty]
    private string _color;

}
