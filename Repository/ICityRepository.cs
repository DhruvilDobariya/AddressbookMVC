using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface ICityRepository
    {
        string Message { get; set; }
        IEnumerable<City> GetAllWithJoin();
    }
}
