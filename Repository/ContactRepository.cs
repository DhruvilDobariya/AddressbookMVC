using Addressbook.Models;

namespace Addressbook.Repository
{
    public class ContactRepository : IContactRepository
    {
        public string Message { get; set; }

        public IEnumerable<Contact> GetAllWithJoin()
        {
            throw new NotImplementedException();
        }
    }
}
