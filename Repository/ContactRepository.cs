using Addressbook.Models;

namespace Addressbook.Repository
{
    public class ContactRepository : IContactRepository
    {
        public Task<IEnumerable<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
