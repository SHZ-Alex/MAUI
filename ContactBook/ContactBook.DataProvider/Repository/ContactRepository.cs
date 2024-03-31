using Contacts.BLL.Repository;
using SQLite;
using Contact = ContactBook.Core.Contact;

namespace ContactBook.DataProvider.Repository;

public class ContactRepository : IContactRepository
{
    private readonly SQLiteAsyncConnection dbContext;

    public ContactRepository()
    {
        dbContext = new SQLiteAsyncConnection(Constants.DatabasePath);
        dbContext.CreateTableAsync<Contact>();
    }

    public async Task<Contact> GetContactByIdAsync(int contactId)
    {
        return await dbContext.Table<Contact>()
            .Where(x => x.Id == contactId)
            .FirstAsync();
    }

    public async Task UpdateContact(int id, Contact contact)
    {
        await dbContext.UpdateAsync(contact);
    }

    public async Task AddContact(Contact contact)
    {
        await dbContext.InsertAsync(contact);
    }

    public async Task DeleteContact(int contactId)
    {
        var contact = await GetContactByIdAsync(contactId);
        await dbContext.DeleteAsync(contact);
    }

    public async Task<ICollection<Contact>> GetContactsAsync(string filterText)
    {
        if (string.IsNullOrWhiteSpace(filterText))
        {
            return await dbContext.Table<Contact>()
                .ToArrayAsync();
        }

        var a = new Contact();

        return await dbContext.QueryAsync<Contact>(@"
            SELECT *
            FROM Contact
            WHERE
                Name LIKE ? OR 
                Email LIKE ? OR 
                Phone LIKE ? OR 
                Address LIKE ?", 
            $"{filterText}",
            $"{filterText}",
            $"{filterText}",
            $"{filterText}");
    }
}