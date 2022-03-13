using Addressbook.GenericRepository;
using Addressbook.Models;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AddressBookContext _db;
        public string _Message { get; set; }

        public CountryRepository(AddressBookContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            List<Country> countries = new List<Country>();
            try
            {
                countries = await _db.Countries.ToListAsync();
                if(countries.Count == 0)
                {
                    _Message = "No Record";
                }
                return countries;
            }
            catch (Exception ex)
            {
                _Message = ex.Message;
                return countries;
            }
        }
    }
}
