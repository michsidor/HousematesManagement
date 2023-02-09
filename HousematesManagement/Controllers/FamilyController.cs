using HousemateManagement.Models.Family.Command;
using HousemateManagement.Models.Family.Dto;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HousemateManagement.Controllers
{
    [ApiController]
    [Route("api/family")]
    [EnableCors("MyOwnPolicy")]
    public class FamilyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FamilyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<string>> Login([FromBody] FamilyDto modelDto, [FromRoute] Guid id)
        {
            await _mediator.Send(new LoginToFamilyCommand() 
            { 
                ModelDto = modelDto,
                UserId = id
            });

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Add([FromBody] AddFamilyDto modelDto, [FromRoute] Guid id)
        {

            await _mediator.Send(new AddFamilyCommand()
            {
                ModelDto = modelDto,
                UserId = id
            });

            return Ok();
        }
    }
}