using Contact = ContactBook.Core.Contact;
using ContactBook.DataProvider.Repository;
using Contacts.BLL.BLL.ViewContactBll;

namespace ContactBook.Maui.Views;

public partial class AddContactPage : ContentPage
{
    private readonly IViewContactBll _viewContactBll;

    public AddContactPage(IViewContactBll viewContactBll)
	{
		InitializeComponent();
        _viewContactBll = viewContactBll;
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private async void contactCtrl_OnSave(object sender, EventArgs e)
    {
        var newEntity = new Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Phone = contactCtrl.Phone,
            Address = contactCtrl.Address
        };

        await _viewContactBll.AddContact(newEntity);

        await Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}