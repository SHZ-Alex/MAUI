using ContactBook.Core;

namespace Contacts.BLL.Repository;

public interface IContactRepository
{
    Task<ICollection<Contact>> GetContactsAsync(string filterText);
    Task<Contact> GetContactByIdAsync(int contactId);
    Task UpdateContact(int contactId, Contact contact);
    Task DeleteContact(int contactId);
    Task AddContact(Contact contact);
}