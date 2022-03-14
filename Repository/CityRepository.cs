using Addressbook.Models;

namespace Addressbook.Repository
{
    public class CityRepository : ICityRepository
    {
        public string Message { get; set; }

        public IEnumerable<City> GetAllWithJoin()
        {
            throw new NotImplementedException();
        }
    }
}
