using Entity.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace HousemateManagement.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public TaskController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public async Task<ActionResult<string>> Get()
        {
            var result = await _context.Users.ToListAsync();   
            var resultJson = JsonSerializer.Serialize(result);

            return Ok(resultJson);
        }
    }
}
