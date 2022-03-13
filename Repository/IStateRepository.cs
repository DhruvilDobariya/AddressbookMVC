using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllAsync();
    }
}
