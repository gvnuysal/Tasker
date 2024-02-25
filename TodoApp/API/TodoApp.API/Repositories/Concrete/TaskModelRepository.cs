using TodoApp.API.Repositories.Abstract;
using TodoApp.API.Repositories.Concrete.Common;
using TodoApp.Core.Models;

namespace TodoApp.API.Repositories.Concrete
{
    public class TaskModelRepository : GenericRepository<TaskModel>, ITaskModelRepository
    {
        public TaskModelRepository(TodoAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
