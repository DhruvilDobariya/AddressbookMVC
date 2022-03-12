using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAll();

        Task<Country> GetById(int id);

        Task<bool> Insert(Country country);

        Task<bool> Update(Country country);

        Task<bool> Delete(int id);
    }
}
