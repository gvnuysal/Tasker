using Microsoft.AspNetCore.Mvc;
using TodoApp.API.Repositories.Abstract;
using TodoApp.Core.Models;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskModelRepository _taskModelRepository;

        public TaskController(ITaskModelRepository taskModelRepository)
        {
            _taskModelRepository = taskModelRepository;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllTaskAsync()
        {
            var result = await _taskModelRepository.GetAllAsync();

            return Ok(result);
        }
        [HttpGet]
        [Route("get-all/{status}")]
        public async Task<IActionResult> GetAllTaskAsync(int status)
        {
            var result = await _taskModelRepository.GetAllAsync(x => (int)x.Status == status);

            return Ok(result);
        }
        [HttpGet]
        [Route("get-all-search/{search}")]
        public async Task<IActionResult> GetAllTaskAsync(string search)
        {
            search = search.ToLower();
            var result = await _taskModelRepository.GetAllAsync(x => x.Title.Contains(search) ||
                                                                    x.Content.Contains(search));

            return Ok(result);
        }
        [HttpGet]
        [Route("get-all-today")]
        public async Task<IActionResult> GetAllTodayTaskAsync()
        {
            var result = await _taskModelRepository.GetAllAsync(x => x.TaskDate.Date == DateTime.Now.Date);

            return Ok(result);
        }
        [HttpGet]
        [Route("get-all-today")]
        public async Task<IActionResult> GetAllTodayTaskAsync([FromQuery] string date)
        {
            if(DateTime.TryParse(date,out DateTime dateTime))
            {
                var result = await _taskModelRepository.GetAllAsync(x => x.TaskDate.Date == dateTime.Date);

                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskAsync(int id)
        {
            var result=await _taskModelRepository.GetSingleAsync(x=>x.Id==id);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddTaskAsync([FromBody] TaskModel input)
        {
            var result=await _taskModelRepository.InsertAsync(input);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            var result = await _taskModelRepository.RemoveAsync(id);

            return Ok(result);
        }
        [HttpDelete]
        [Route("delete-range")]
        public async Task<IActionResult> DeleteRangeTaskAsync(List<int> ids)
        {
            var result = await _taskModelRepository.RemoveRangeAsync(ids);

            return Ok(result);
        }
    }
}
