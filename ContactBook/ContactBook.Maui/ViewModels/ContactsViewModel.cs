using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactBook.Maui.Views;
using Contacts.BLL.BLL.ViewContactBll;
using Contact = ContactBook.Core.Contact;

namespace ContactBook.Maui.ViewModels;

public partial class ContactsViewModel(IViewContactBll viewContactBll) : ObservableObject
{
    public ObservableCollection<Contact> Contacts { get; set; } = [];

    public async Task LoadContacts()
    {
        Contacts.Clear();
        var contacts = await viewContactBll.GetContacts(string.Empty);

        foreach (var contact in contacts)
            Contacts.Add(contact);
    }

    [RelayCommand]
    public async Task DeleteContact(int contactId)
    {
        await viewContactBll.DeleteContact(contactId);
        await LoadContacts();
    }

    [RelayCommand]
    public async Task EditContact(int contactId)
        => await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={contactId}");
    
    [RelayCommand]
    public async Task GoToAddContact()
        => await Shell.Current.GoToAsync($"{nameof(AddContactPage)}");

    [RelayCommand]
    public async Task Search(string filterText)
    {
        Contacts.Clear();
        var contacts = await viewContactBll.GetContacts(filterText);
        foreach (var contact in contacts) Contacts.Add(contact);
    }
}