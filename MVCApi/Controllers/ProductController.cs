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
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) {
            _mediator = mediator;
        }        

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProduct command) {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("{ProductId}")]
        public async Task<ActionResult<Product>> GetCartById([FromRoute] GetProductById query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}