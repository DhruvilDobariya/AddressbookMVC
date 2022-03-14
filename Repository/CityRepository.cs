using Addressbook.Models;

namespace Addressbook.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly AddressBookContext _db;
        public string Message { get; set; }

        public CityRepository(AddressBookContext db)
        {
            _db = db;
        }

        public IEnumerable<City> GetAllWithJoin()
        {
            IQueryable<City> cities = from City in _db.Cities
                                      join State in _db.States on City.StateId equals State.StateId
                                      select new City
                                      {
                                          CityId = City.CityId,
                                          CityName = City.CityName,
                                          StateId = City.StateId,
                                          PinCode = City.PinCode,
                                          Stdcode = City.Stdcode,
                                          State = City.State,
                                          CreationDate = City.CreationDate
                                      };
            return cities;
        }
    }
}
