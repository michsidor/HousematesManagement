using HousemateManagement.Tasks.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HousemateManagement.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetOne() // request: https://localhost:7021/api/task
        {
            var result = await _mediator.Send(new GetTaskQuery() { Id = Guid.Parse("938AD847-5DA3-43C6-9BB5-16666F03E57B") });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpGet("all")]
        public async Task<ActionResult<string>> GetAll() // request: https://localhost:7021/api/task/all
        {
            var result = await _mediator.Send(new GetAllTasksQuery() { Id = Guid.Parse("938AD847-5DA3-43C6-9BB5-16666F03E57B") });
       
            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<string>> Add()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Update()
        {
            return Ok();
        }
    }
}
