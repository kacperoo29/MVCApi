using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCApi.Application.Commands;
using MVCApi.Application.Dto;
using MVCApi.Application.Queries;

namespace MVCApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AddressDto>> GetAddressById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetAddressById { AddressId = id}));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Guid>> EditAddress([FromRoute] Guid id, [FromBody] EditAddress command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }
    }
}