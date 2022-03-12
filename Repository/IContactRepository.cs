using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
    }
}
