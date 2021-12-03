using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCApi.Application.Commands;
using MVCApi.Application.Dto;
using MVCApi.Application.Queries;

namespace MVCApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> AddProductToCart([FromBody] AddProductToCart command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCart([FromBody] CreateCart command)
        {
            return Ok(await _mediator.Send(new CreateCart()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ShoppingCartDto>> GetCartById([FromRoute] Guid id, [FromQuery] string currencyCode)
        {
            return Ok(await _mediator.Send(new GetCartById { CartId = id, CurrencyCode = currencyCode }));
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> ChangeProductCount([FromBody] ChangeProductCountInCart command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> RemoveProduct([FromBody] RemoveProductFromCart command) 
        {
            return Ok(await _mediator.Send(command));
        }
    }
}