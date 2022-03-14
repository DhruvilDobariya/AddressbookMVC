using Addressbook.Models;

namespace Addressbook.Repository
{
    public class ContactCategoryRepository : IContactCategoryRepository
    {
        public string Message { get; set; }

        public IEnumerable<ContactCategory> GetAllWithJoin()
        {
            throw new NotImplementedException();
        }
    }
}
