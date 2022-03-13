using Addressbook.Models;

namespace Addressbook.Repository
{
    public class CityRepository : ICityRepository
    {
        public Task<IEnumerable<City>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
