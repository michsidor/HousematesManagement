using HousemateManagement.Models.Assignments.Commands;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HousemateManagement.Controllers
{
    [Route("api/assignment")]
    [ApiController]
    [EnableCors("MyOwnPolicy")]
    public class AssignmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AssignmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOne([FromRoute] Guid id) 
        {
            var result = await _mediator.Send(new GetAssignmentQuery() { Id = id });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpGet(("all/{id}"))]
        public async Task<ActionResult<string>> GetAll([FromRoute] Guid id) 
        {
            var result = await _mediator.Send(new GetAllAssignmentsQuery() { Id = id });
       
            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete([FromRoute] Guid id)
        {
            var listGuids = new List<Guid>()
            {
                Guid.Parse(id.ToString())
            };

            await _mediator.Send(new DeleteAssignmentCommand() { Ids = listGuids });

            return Ok("Succesfully deleted assignments");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Add([FromBody] AssignmentDto assignmentDto, [FromRoute] Guid id)
        {
            await _mediator.Send(new AddAssignmentCommand() 
            { 
                AssigmentDto = assignmentDto,
                UserId = id 
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
