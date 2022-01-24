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
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrder command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult<OrderDto>> GetOrderById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetOrderById { OrderId = id }));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders([FromQuery] string currencyCode)
        {
            return Ok(await _mediator.Send(new GetAllOrders { CurrencyCode = currencyCode }));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersInDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string currencyCode)
        {
            return Ok(await _mediator.Send(new GetOrdersInDateRange { StartDate = startDate, EndDate = endDate, CurrencyCode = currencyCode }));
        }
    }
}