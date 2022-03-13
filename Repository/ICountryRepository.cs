using Addressbook.GenericRepository;
using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();
    }
}
