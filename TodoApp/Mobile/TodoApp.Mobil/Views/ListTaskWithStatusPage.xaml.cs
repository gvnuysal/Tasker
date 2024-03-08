using TodoApp.Mobil.ViewModel;

namespace TodoApp.Mobil.Views;

public partial class ListTaskWithStatusPage : ContentPage
{
	public ListTaskWithStatusPage(ListTaskWithStatusViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}