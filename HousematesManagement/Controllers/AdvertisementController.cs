using HousemateManagement.Models.Advertisements.Commands;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HousemateManagement.Controllers
{
    [Route("api/advertisement")]
    [ApiController]
    [EnableCors("MyOwnPolicy")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdvertisementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOne([FromRoute] Guid id) 
        {
            var result = await _mediator.Send(new GetDirectAdvertisementsQuery() { Id = id });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpGet(("all/{id}"))]
        public async Task<ActionResult<string>> GetAll([FromRoute] Guid id) 
        {
            var result = await _mediator.Send(new GetAllAdvertisementsQuery() { Id = id });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete([FromRoute] Guid id)
        {
            var listGuids = new List<Guid>()
            {
                Guid.Parse(id.ToString())
            };

            await _mediator.Send(new DeleteAdvertisementCommand() { ModelsIds = listGuids });

            return Ok("Succesfully deleted advertisements");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Add([FromBody] AdvertisementDto advertisementDto, [FromRoute] Guid id)
        {
            await _mediator.Send(new AddAdvertisementCommand()
            {
                AdvertisementDto = advertisementDto,
                UserId = id
            });

            return Ok("Succesfully added advertisement");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Update([FromBody] AdvertisementDto advertisementDto)
        {
            await _mediator.Send(new UpdateAdvertisementCommand()
            {
                AdvertisementDto = advertisementDto
            });

            return Ok("Succesfully updated advertisement");
        }
    }
}
