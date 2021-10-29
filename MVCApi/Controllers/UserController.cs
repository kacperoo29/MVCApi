using System;
using System.Collections;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCApi.Application.Commands;
using MVCApi.Application.Queries;
using MVCApi.Domain.Entites;

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
    }
}