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
    public class ContactInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ContactInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ContactInfoDto>> GetContactInfoById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetContactInfoById { ContactInfoId = id}));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Guid>> EditContactInfo([FromRoute] Guid id, [FromBody] EditContactInfo command)
        {
            command.ContactInfoId = id;
            return Ok(await _mediator.Send(command));
        }
    }
}