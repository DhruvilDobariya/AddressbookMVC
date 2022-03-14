using Addressbook.Models;

namespace Addressbook.Repository
{
    public interface IStateRepository
    {
        string Message { get; set; }
        IEnumerable<State> GetAllWithJoin();
    }
}
