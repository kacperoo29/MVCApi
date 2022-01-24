using System;
using System.Collections.Generic;
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
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateCustomer([FromBody] CreateCustomer command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetCustomerById {CustomerId = id}));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            return Ok(await _mediator.Send(new GetAllCustomers()));
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> EditCustomer([FromRoute] Guid id, [FromBody] EditCustomer command)
        {
            command.CustomerId = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> AddAddress([FromBody] AddAddress command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> AddContactInfo([FromBody] AddContactInfo command) 
        {
            return Ok(await _mediator.Send(command));
        }
    } 
}