using Contacts.BLL.BLL.ViewContactBll;
using Contact = ContactBook.Core.Contact;

namespace ContactBook.Maui.Views;


[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;
	private readonly IViewContactBll _viewContactBll;

	public EditContactPage(IViewContactBll viewContactBll)
	{
		InitializeComponent();
		_viewContactBll = viewContactBll;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();

		contact = await _viewContactBll.GetContact(int.Parse(ContactId));
	}

	private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    public string ContactId { get; set; }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {


		contact.Name = contactCtrl.Name;
		contact.Email = contactCtrl.Email;
		contact.Address = contactCtrl.Address;
		contact.Phone = contactCtrl.Phone;

		await _viewContactBll.UpdateContact(int.Parse(ContactId), contact);
        await Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}