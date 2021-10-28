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
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator) {
            _mediator = mediator;
        }        

        [HttpPut]
        public async Task<ActionResult<Guid>> AddProductToCart([FromBody] AddProductToCart command) {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCart([FromBody] CreateCart command) {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("{CartId}")]
        public async Task<ActionResult<ShoppingCart>> GetCartById([FromRoute] GetCartById query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}