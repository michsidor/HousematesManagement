using HousemateManagement.Models.Payments.Commands;
using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Models.Payments.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HousemateManagement.Controllers
{
    [Route("api/payment")]
    [ApiController]
    [EnableCors("MyOwnPolicy")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOne([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetDirectPaymentsQuery() { Id = id });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpGet("all/{id}")]
        public async Task<ActionResult<string>> GetAll([FromRoute] Guid id) 
        {
            var result = await _mediator.Send(new GetAllPaymentsQuery() { Id = id });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeletePaymentCommand() { Id = id });

            return Ok("Succesfully deleted payments");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Add([FromBody] PaymentDto paymantDto, [FromRoute] Guid id)
        {
            await _mediator.Send(new AddPaymentCommand()
            {
                PaymentDto = paymantDto,
                UserId = id
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
