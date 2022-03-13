using Addressbook.Models;

namespace Addressbook.Repository
{
    public class ContactCategoryRepository : IContactCategoryRepository
    {
        public Task<IEnumerable<ContactCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
