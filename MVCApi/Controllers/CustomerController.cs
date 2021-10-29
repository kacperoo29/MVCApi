using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCApi.Application.Commands;
using MVCApi.Application.Queries;
using MVCApi.Domain.Entites;

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
        public async Task<ActionResult<Customer>> GetCustomerById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetCustomerById { CustomerId = id }));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            return Ok(await _mediator.Send(new GetAllCustomers()));
        }
    }
}