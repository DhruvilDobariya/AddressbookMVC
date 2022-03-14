using Addressbook.Models;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.GenericRepository
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        private readonly AddressBookContext _db;
        private readonly DbSet<T> _entities;

        public string Message { get; set; }

        public CRUDRepository(AddressBookContext db)
        {
            _db = db;
            _entities = _db.Set<T>(); // For Ex : If we have 'Country' then it becomes '_db.Countries'
        }

        public async Task<T> GetByIdAsync(int id)
        {
            
            try
            {
                var entity = await _entities.FindAsync(id); // For Ex : If we have 'Country' then it becomes '_db.Countries.FindAsync(id)'
                if (entity == null)
                {
                    Message = "Not Found";
                    return entity;
                }
                return entity;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }

        public async Task<bool> InsertAsync(T entity)
        {
            try
            {
                await _db.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Violation of UNIQUE KEY constraint") || ex.ToString().Contains("Cannot insert duplicate key row in object"))
                {
                    Message = "This item already exist";
                    return false;
                }
                Message = ex.Message;
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _db.Update(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                if(ex.ToString().Contains("Violation of UNIQUE KEY constraint") || ex.ToString().Contains("Cannot insert duplicate key row in object"))
                {
                    Message = "This item already exist";
                    return false;
                }
                Message = ex.Message;
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _entities.FindAsync(id);
                if(entity == null)
                {
                    Message = "Not Found";
                    return false;
                }
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                if(ex.ToString().Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    Message = "This item contain some record, so first you must delete these record, if you want to delete this item.";
                    return false;
                }
                Message = ex.Message;
                return false;

            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> entities = new List<T>();
            try
            {
                entities = await _entities.ToListAsync();
                return entities;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                return entities;
            }
        }
    }
}
