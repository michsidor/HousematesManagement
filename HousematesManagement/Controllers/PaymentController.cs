using HousemateManagement.Models.Assignments.Commands;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HousemateManagement.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetOne()
        {
            return Ok();
        }

        [HttpGet("all")]
        public async Task<ActionResult<string>> GetAll() 
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
