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
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserDto modelDto)
        {
            var result = await _mediator.Send(new LoginUserQuery() { loginUserDto= modelDto });

            if (result != Guid.Empty)
            {
                return Ok(result);
            }

            return BadRequest("Wrong user name or password");
        }

        [HttpPut]
        public async Task<ActionResult<string>> Register([FromBody] UserDto modelDto)
        {
            await _mediator.Send(new RegisterUserCommand() { UserDto = modelDto});

            return Ok("Succesfully registered new User");
        }
    }
}
