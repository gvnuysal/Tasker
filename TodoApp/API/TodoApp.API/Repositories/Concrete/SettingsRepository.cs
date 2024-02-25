using TodoApp.API.Repositories.Abstract;
using TodoApp.API.Repositories.Concrete.Common;
using TodoApp.Core.Models;

namespace TodoApp.API.Repositories.Concrete
{
    public class SettingsRepository : GenericRepository<SettingsModel>, ISettingsRepository
    {
        public SettingsRepository(TodoAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
