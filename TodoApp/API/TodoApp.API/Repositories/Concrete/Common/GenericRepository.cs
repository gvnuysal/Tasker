using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using TodoApp.API.Repositories.Abstract.Common;
using TodoApp.Core.Models.Common;

namespace TodoApp.API.Repositories.Concrete.Common
{
    public class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : BaseModel
    {
        private readonly TodoAppDbContext _dbContext;

        public GenericRepository(TodoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TSource> Table => _dbContext.Set<TSource>();

        public async Task<List<TSource>?> GetAllAsync() => await Table.AsNoTracking().ToListAsync();

        public async Task<List<TSource>?> GetAllAsync(Expression<Func<TSource, bool>> filter) => await Table.AsNoTracking().Where(filter).ToListAsync();

        public async Task<int> GetCountAsync() => await Table.CountAsync();


        public async Task<int> GetCountAsync(Expression<Func<TSource, bool>> filter) => await Table.CountAsync(filter);

        public async Task<TSource?> GetSingleAsync(Expression<Func<TSource, bool>> filter) => await Table.FirstOrDefaultAsync(filter);
        public async Task<bool> InsertAsync(TSource item)
        {
            try
            {
                EntityEntry<TSource> entry = await Table.AddAsync(item);
                await SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var model = await Table.FirstOrDefaultAsync(x => x.Id == id);
                Table.Remove(model);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                var message=ex.Message;
                return false;
            }
        }

        public async Task<bool> RemoveRangeAsync(List<int> ids)
        {
            try
            {
                var model = await Table.AsNoTracking().Where(x => ids.Contains(x.Id)).ToListAsync();
                Table.RemoveRange(model);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         
        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
        public int Save()=>_dbContext.SaveChanges();

        public async Task<bool> UpdateAsync(TSource item)
        {
            try
            {
                EntityEntry<TSource> entityEntry = Table.Update(item);
                await SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
        }
    }
}
