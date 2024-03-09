using TodoApp.Mobil.ViewModel;

namespace TodoApp.Mobil.Views;

public partial class DetailTaskPage : ContentPage
{
	public DetailTaskPage(DetailTaskViewModel detailTaskViewModel)
	{
		InitializeComponent();
		BindingContext = detailTaskViewModel;
	}
}