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
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrder command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> GetOrderById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetOrderById { OrderId = id }));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            return Ok(await _mediator.Send(new GetAllOrders()));
        }

    }
}