using System.Collections.ObjectModel;
using Contacts.BLL.BLL.ViewContactBll;
using Contact = ContactBook.Core.Contact;

namespace ContactBook.Maui.Views;

public partial class ContactsPage : ContentPage
{
    private readonly IViewContactBll _viewContactBll;

    public ContactsPage(IViewContactBll viewContactBll)
	{
		InitializeComponent();
        _viewContactBll = viewContactBll;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SearchBar.Text = string.Empty;

        LoadContacts();
    }

    private void btnEditContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null) 
        {
            var uri = $"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).Id}";
            await Shell.Current.GoToAsync(uri);
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var contact = (Contact)(sender as MenuItem).CommandParameter;
        
        await _viewContactBll.DeleteContact(contact.Id);

        LoadContacts();
    }

    private async void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(await _viewContactBll.GetContacts(string.Empty));
        listContacts.ItemsSource = contacts;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(await _viewContactBll.GetContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }
}

