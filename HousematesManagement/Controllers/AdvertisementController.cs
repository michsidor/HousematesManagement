using HousemateManagement.Models.Assignments.Commands;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HousemateManagement.Controllers
{
    [Route("api/advertisement")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdvertisementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetOne() // request: https://localhost:7021/api/task
        {
            return Ok();
        }

        [HttpGet("all")]
        public async Task<ActionResult<string>> GetAll() // request: https://localhost:7021/api/task/all
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<string>> Add([FromBody] AssignmentDto assignmentDto)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Update([FromBody] AssignmentDto assignmentDto)
        {
            return Ok();
        }
    }
}
