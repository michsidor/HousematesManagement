using HousemateManagement.Models.Assignments.Commands;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HousemateManagement.Controllers
{
    [Route("api/assignment")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AssignmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetOne() // request: https://localhost:7021/api/task
        {
            var result = await _mediator.Send(new GetAssignmentQuery() { Id = Guid.Parse("56725F34-35AF-4455-AC9E-79F4959A6418") });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpGet("all")]
        public async Task<ActionResult<string>> GetAll() // request: https://localhost:7021/api/task/all
        {
            var result = await _mediator.Send(new GetAllAssignmentsQuery() { Id = Guid.Parse("56725F34-35AF-4455-AC9E-79F4959A6418") });
       
            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete()
        {
            var listGuids = new List<Guid>()
            {
                Guid.Parse("83CE2A4D-F930-41D7-B483-2584F4C3391C")
            };

            await _mediator.Send(new DeleteAssignmentCommand() { Ids = listGuids });

            return Ok("Succesfully deleted assignments");
        }

        [HttpPut]
        public async Task<ActionResult<string>> Add([FromBody] AssignmentDto assignmentDto)
        {
            await _mediator.Send(new AddAssignmentCommand() 
            { 
                AssigmentDto = assignmentDto,
                UserId = Guid.Parse("56725F34-35AF-4455-AC9E-79F4959A6418") 
            });

            return Ok("Succesfully added assignment");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Update([FromBody] AssignmentDto assignmentDto)
        {
            await _mediator.Send(new UpdateAssignmentCommand() 
            { 
                AssignmentDto = assignmentDto
            });

            return Ok("Succesfully updated assignment");
        }
    }
}
