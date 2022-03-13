using Addressbook.Models;

namespace Addressbook.Repository
{
    public class StateRepository : IStateRepository
    {
        public Task<IEnumerable<State>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
