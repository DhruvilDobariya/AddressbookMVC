using Addressbook.Models;

namespace Addressbook.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly AddressBookContext _db;
        public string Message { get; set; }

        public StateRepository(AddressBookContext db)
        {
            _db = db;
        }
        public IEnumerable<State> GetAllWithJoin()
        {
            try
            {
                var states = from State in _db.States
                            join Country in _db.Countries on State.CountryId equals Country.CountryId
                            select new State
                            {
                                StateId = State.StateId,
                                CountryId = Country.CountryId,
                                StateCode = State.StateCode,
                                StateName = State.StateName,
                                CreationDate = State.CreationDate,
                                Country = Country,
                            };
                return states;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }
    }
}
