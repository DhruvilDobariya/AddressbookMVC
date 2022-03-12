namespace Addressbook.GenericRepository
{
    public interface ICRUDRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
