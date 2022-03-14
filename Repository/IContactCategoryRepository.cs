using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface IContactCategoryRepository
    {
        string Message { get; set; }
        IEnumerable<ContactCategory> GetAllWithJoin();
    }
}
