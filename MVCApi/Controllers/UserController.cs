using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCApi.Application.Commands;
using MVCApi.Application.Dto;
using MVCApi.Application.Queries;

namespace MVCApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUser command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<AuthResponseDto>> SignIn([FromBody] SignIn command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ApplicationUserDto>> GetCurrentUser()
        {
            return Ok(await _mediator.Send(new GetCurrentUser()));
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> LinkCustomer([FromBody] LinkCustomer command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateRole([FromBody] CreateRole command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}