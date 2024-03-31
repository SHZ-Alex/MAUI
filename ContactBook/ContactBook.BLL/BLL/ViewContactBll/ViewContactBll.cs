using ContactBook.Core;
using Contacts.BLL.Repository;

namespace Contacts.BLL.BLL.ViewContactBll;

public class ViewContactBll(IContactRepository contactRepository) : IViewContactBll
{
    public async Task<Contact> GetContact(int contactId) =>
        await contactRepository.GetContactByIdAsync(contactId);

    public async Task UpdateContact(int contactId, Contact contact) =>
        await contactRepository.UpdateContact(contactId, contact);

    public async Task DeleteContact(int contactId) =>
        await contactRepository.DeleteContact(contactId);

    public async Task AddContact(Contact contact) =>
        await contactRepository.AddContact(contact);

    public async Task<IEnumerable<Contact>> GetContacts(string filterText)
        => await contactRepository.GetContactsAsync(filterText);
    
}