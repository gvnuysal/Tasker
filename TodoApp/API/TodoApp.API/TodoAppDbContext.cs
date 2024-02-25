using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Models;

namespace TodoApp.API
{
    public class TodoAppDbContext:DbContext
    {
        public DbSet<TaskModel> TaskModel { get; set; }
        public DbSet<SettingsModel> Settings { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
