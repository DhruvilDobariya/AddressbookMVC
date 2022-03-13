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
                Message = ex.Message;
                return false;
            }
        }
    }
}
