using Addressbook.GenericRepository;
using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface ICountryRepository
    {
        string Message { get; set; }
        IEnumerable<Country> GetAll();
    }
}
