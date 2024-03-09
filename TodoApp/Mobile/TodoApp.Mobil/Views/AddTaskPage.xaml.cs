using TodoApp.Mobil.ViewModel;

namespace TodoApp.Mobil.Views;

public partial class AddTaskPage : ContentPage
{
	public AddTaskPage(AddTaskViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=viewModel;
	}
}