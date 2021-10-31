using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCApi.Application.Commands;
using MVCApi.Application.Dto;
using MVCApi.Application.Queries;

namespace MVCApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProduct command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("{ProductId}")]
        public async Task<ActionResult<ProductDto>> GetProductById([FromRoute] GetProductById query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}