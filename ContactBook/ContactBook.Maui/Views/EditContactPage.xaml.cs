using ContactBook.Maui.ViewModels;

namespace ContactBook.Maui.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    public required string ContactId { get; set; }
    
    private readonly ContactViewModel _viewModelContact;

    public EditContactPage(ContactViewModel viewModelModel)
    {
        InitializeComponent();
        _viewModelContact = viewModelModel;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModelContact.LoadContact(ContactId);
        
        BindingContext = _viewModelContact;
    }

    // private async void LoadContact()
    // {
    //     contact = await ViewModelContact.GetContact(int.Parse(ContactId));
    //
    //     contactCtrl.Name = contact.Name!;
    //     contactCtrl.Email = contact.Email!;
    //     contactCtrl.Phone = contact.Address!;
    //     contactCtrl.Address = contact.Phone!;
    // }
    //
    // private void btnCancel_Clicked(object sender, EventArgs e)
    // {
    //     Shell.Current.GoToAsync("..");
    // }
    //
    //
    // private void btnUpdate_Clicked(object sender, EventArgs e)
    // {
    //     contact.Name = contactCtrl.Name;
    //     contact.Email = contactCtrl.Email;
    //     contact.Address = contactCtrl.Address;
    //     contact.Phone = contactCtrl.Phone;
    //
    //     ViewModelContact.UpdateContact(contact.Id, contact);
    //     Shell.Current.GoToAsync("..");
    // }
    //
    // private void contactCtrl_OnError(object sender, string e)
    // {
    //     DisplayAlert("������", e, "Ok");
    // }
}