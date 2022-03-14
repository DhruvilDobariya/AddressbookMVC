using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface IContactRepository
    {
        string Message { get; set; }
        IEnumerable<Contact> GetAllWithJoin();
    }
}
