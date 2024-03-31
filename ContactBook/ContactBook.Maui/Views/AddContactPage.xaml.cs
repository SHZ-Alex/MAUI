using ContactBook.Maui.ViewModels;
using Contact = ContactBook.Core.Contact;

namespace ContactBook.Maui.Views;

public partial class AddContactPage : ContentPage
{
    private readonly ContactViewModel _viewModel;

    public AddContactPage(ContactViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _viewModel.Contact = new Contact
        {
            Email = string.Empty,
            Name = string.Empty
        };
    }
}