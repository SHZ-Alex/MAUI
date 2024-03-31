using ContactBook.Core;

namespace Contacts.BLL.BLL.ViewContactBll;

public interface IViewContactBll
{
    Task<Contact> GetContact(int contactId);
    Task UpdateContact(int contactId, Contact contact);
    Task<IEnumerable<Contact>> GetContacts(string filterText);
    Task DeleteContact(int contactId);
    Task AddContact(Contact contact);
}