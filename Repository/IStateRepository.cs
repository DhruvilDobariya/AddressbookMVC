using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface IStateRepsitory
    {
        Task<IEnumerable<State>> GetAllAsync();
    }
}
