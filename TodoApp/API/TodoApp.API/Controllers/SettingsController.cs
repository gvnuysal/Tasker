using Microsoft.AspNetCore.Mvc;
using TodoApp.API.Repositories.Abstract;
using TodoApp.Core.Models;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : Controller
    {
       private readonly ISettingsRepository _settingsRepository;

        public SettingsController(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetSettingsAsync()
        {
            var result = await _settingsRepository.GetSingleAsync(x=>x.Id==1);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddSettingsAsync([FromBody] SettingsModel input)
        {
            var result = await _settingsRepository.InsertAsync(input);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> GetSettingsAsync([FromBody] SettingsModel input)
        {
            var result = await _settingsRepository.UpdateAsync(input);
            return Ok(result);
        }
    }
}
