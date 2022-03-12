using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface IContactCategoryRepository
    {
        Task<IEnumerable<ContactCategory>> GetAllAsync();
    }
}
