using HousemateManagement.Models.Advertisements.Commands;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Queries;
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
        public async Task<ActionResult<string>> GetOne() // request: https://localhost:7021/api/advertisement
        {
            var result = await _mediator.Send(new GetDirectAdvertisementsQuery() { Id = Guid.Parse("56725F34-35AF-4455-AC9E-79F4959A6418") });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpGet("all")]
        public async Task<ActionResult<string>> GetAll() // request: https://localhost:7021/api/advertisement/all
        {
            var result = await _mediator.Send(new GetAllAdvertisementsQuery() { Id = Guid.Parse("56725F34-35AF-4455-AC9E-79F4959A6418") });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete()
        {
            var listGuids = new List<Guid>()
            {
                Guid.Parse("83CE2A4D-F930-41D7-B483-2584F4C3391C")
            };

            await _mediator.Send(new DeleteAdvertisementCommand() { ModelsIds = listGuids });

            return Ok("Succesfully deleted advertisements");
        }

        [HttpPut]
        public async Task<ActionResult<string>> Add([FromBody] AdvertisementDto advertisementDto)
        {
            await _mediator.Send(new AddAdvertisementCommand()
            {
                AdvertisementDto = advertisementDto,
                UserId = Guid.Parse("56725F34-35AF-4455-AC9E-79F4959A6418")
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
