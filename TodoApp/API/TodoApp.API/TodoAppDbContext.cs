using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Models;
using TodoApp.Core.Models.Common;

namespace TodoApp.API
{
    public class TodoAppDbContext:DbContext
    {
        public TodoAppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<SettingsModel> Settings { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseModel>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added=>data.Entity.CreatedDate=DateTime.Now,
                    EntityState.Modified=>data.Entity.UpdatedDate=DateTime.Now,
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
