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
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCustomer([FromBody] CreateCustomer command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetCustomerById {CustomerId = id}));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            return Ok(await _mediator.Send(new GetAllCustomers()));
        }
    }
}