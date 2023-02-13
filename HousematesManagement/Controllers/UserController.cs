using HousemateManagement.Models.User.Command;
using HousemateManagement.Models.User.Dto;
using HousemateManagement.Models.User.Query;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HousemateManagement.Controllers
{
    [ApiController]
    [Route("api/user")]
    [EnableCors("MyOwnPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserDto modelDto)
        {
            _logger.LogInformation("User called HTTP POST request in User controller");

            var result = await _mediator.Send(new LoginUserQuery() { loginUserDto= modelDto });

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<string>> Register([FromBody] UserDto modelDto)
        {
            _logger.LogInformation($"User called HTTP PUT request in User controller with data {modelDto.Name} and {modelDto.Email}");

            await _mediator.Send(new RegisterUserCommand() { UserDto = modelDto});

            return Ok("Succesfully registered new User");
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<string>> Quit([FromRoute] Guid id)
        {
            _logger.LogInformation("User called HTTP POST request in User controller [QUIT]");

            await _mediator.Send(new QuitFamilyCommand() { Id = id });

            return Ok("Succesfully quited the family");
        }
    }
}
