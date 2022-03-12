using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync();
    }
}
