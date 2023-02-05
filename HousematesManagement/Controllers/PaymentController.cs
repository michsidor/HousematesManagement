using HousemateManagement.Models.Payments.Commands;
using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Models.Payments.Queries;
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
            var result = await _mediator.Send(new GetDirectPaymentsQuery() { Id = Guid.Parse("56725F34-35AF-4455-AC9E-79F4959A6418") });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpGet("all")]
        public async Task<ActionResult<string>> GetAll() 
        {
            var result = await _mediator.Send(new GetAllPaymentsQuery() { Id = Guid.Parse("56725F34-35AF-4455-AC9E-79F4959A6418") });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete()
        {
            var listGuids = new List<Guid>()
            {
                Guid.Parse("83CE2A4D-F930-41D7-B483-2584F4C3391C")
            };

            await _mediator.Send(new DeletePaymentCommand() { ModelsIds = listGuids });

            return Ok("Succesfully deleted payments");
        }

        [HttpPut]
        public async Task<ActionResult<string>> Add([FromBody] PaymentDto paymantDto)
        {
            await _mediator.Send(new AddPaymentCommand()
            {
                PaymentDto = paymantDto,
                UserId = Guid.Parse("56725F34-35AF-4455-AC9E-79F4959A6418")
            });

            return Ok("Succesfully added payment");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Update([FromBody] PaymentDto paymantDto)
        {
            await _mediator.Send(new UpdatePaymentCommand()
            {
                PaymentDto = paymantDto
            });

            return Ok("Succesfully updated payment");
        }
    }
}
