using Addressbook.GenericRepository;
using Addressbook.Models;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AddressBookContext _db;
        public string Message { get; set; }

        public CountryRepository(AddressBookContext db)
        {
            _db = db;
        }

        public IEnumerable<Country> GetAll()
        {
            List<Country> countries = new List<Country>();
            try
            {
                countries = _db.Countries.ToList();
                return countries;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return countries;
            }
        }
    }
}
