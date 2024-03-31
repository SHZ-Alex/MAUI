using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactBook.Maui.Views;
using Contacts.BLL.BLL.ViewContactBll;
using Contact = ContactBook.Core.Contact;

namespace ContactBook.Maui.ViewModels;

public partial class ContactViewModel(IViewContactBll viewContactBll) : ObservableObject
{
    public Contact Contact { get; set; } = default!;
    
    public bool IsNameProvided { get; set; }
    public bool IsEmailProvided { get; set; }
    public bool IsEmailFormatCorrect { get; set; }

    public async Task LoadContact(string contactId)
        => Contact = await viewContactBll.GetContact(int.Parse(contactId));
    

    [RelayCommand]
    public async Task EditContact()
    {
        if (!await ValidateContact())
            return;
        
        await viewContactBll.UpdateContact(Contact.Id, Contact);
        await Shell.Current.GoToAsync($"{nameof(ContactsPage)}");
    }
    
    [RelayCommand]
    public async Task AddContact()
    {
        if (!await ValidateContact())
            return;
        
        await viewContactBll.AddContact(Contact);
        await Shell.Current.GoToAsync($"..");
    }

    [RelayCommand]
    public async Task BackToContacts()
        => await Shell.Current.GoToAsync($"..");

    private async Task<bool> ValidateContact()
    {
        if (IsNameProvided)
            return await DisplayAlertAndReturnFalse("Ошибка", "Имя должно быть заполнено", "Ok");
        
        if (IsEmailProvided)
            return await DisplayAlertAndReturnFalse("Ошибка", "Почта должна быть заполнена", "Ok");

        if (IsEmailFormatCorrect)
            return await DisplayAlertAndReturnFalse("Ошибка", "Почта должна быть корректна", "Ok");

        return true;
    }

    private async Task<bool> DisplayAlertAndReturnFalse(string title, string message, string buttonLabel)
    {
        await Application.Current!.MainPage!.DisplayAlert(title, message, buttonLabel);
        return false;
    }
}