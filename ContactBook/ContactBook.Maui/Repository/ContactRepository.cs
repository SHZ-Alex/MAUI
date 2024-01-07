using ContactBook.Maui.Models;
using Contact = ContactBook.Maui.Models.Contact;

namespace ContactBook.Maui.Repository;

public static class ContactRepository
{
    public static List<Contact> GetContacts = new List<Contact>() {
                    new Contact { Id = 1, Name = "Alex1", Email = "Alex1" },
                    new Contact { Id = 2, Name = "Alex2", Email = "Alex2" },
                    new Contact { Id = 3, Name = "Alex3", Email = "Alex3" },
                    new Contact { Id = 4, Name = "Alex4", Email = "Alex4" },
                    new Contact { Id = 5, Name = "Alex5", Email = "Alex5" } };

    public static Contact GetContactById(int id) 
    {
        var contact = GetContacts.First(x => x.Id == id);
        return new Contact { Id = contact.Id, 
            Name =  contact.Name, 
            Email = contact.Email, 
            Phone = contact.Phone, 
            Address = contact.Address };
    } 

    public static void UpdateContact(int  id, Contact contact)
    {
        var entityContact = GetContacts.First(x => x.Id == id);

        entityContact.Address = contact.Address;
        entityContact.Phone = contact.Phone;
        entityContact.Name = contact.Name;
        entityContact.Email = contact.Email;
    }

    public static void AddContact(Contact contact)
    {
        int id = 0;

        if (GetContacts.Any())
            id = GetContacts.Max(x => x.Id);

        contact.Id = id++;

        GetContacts.Add(contact);
    }

    public static void DeleteContact(int contactId)
    {
        var contact = GetContacts.First(x => x.Id == contactId);
        GetContacts.Remove(contact);
    }

    public static IEnumerable<Contact> SearchContacts(string text)
    {
        var contacts = GetContacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(text, StringComparison.OrdinalIgnoreCase))?.ToList();

        if (contacts != null && contacts.Any())
            return contacts;
        
        contacts = GetContacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(text, StringComparison.OrdinalIgnoreCase))?.ToList();

        if (contacts != null && contacts.Any())
            return contacts;

        contacts = GetContacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(text, StringComparison.OrdinalIgnoreCase))?.ToList();

        if (contacts != null && contacts.Any())
            return contacts;

        contacts = GetContacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(text, StringComparison.OrdinalIgnoreCase))?.ToList();

        if (contacts != null && contacts.Any())
            return contacts;

        return Enumerable.Empty<Contact>();
    }
}
