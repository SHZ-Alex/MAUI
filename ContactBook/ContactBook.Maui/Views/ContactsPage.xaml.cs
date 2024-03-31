using ContactBook.Maui.ViewModels;

namespace ContactBook.Maui.Views;

public partial class ContactsPage : ContentPage
{
	private readonly ContactsViewModel _viewModel;

	public ContactsPage(ContactsViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		
		BindingContext = _viewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.LoadContacts();
	}
}

