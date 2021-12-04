using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCApi.Application.Commands;
using MVCApi.Application.Dto;
using MVCApi.Application.Queries;
using MVCApi.Domain;

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
        [Route("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById([FromRoute] Guid id, [FromQuery] string currencyCode)
        {
            return Ok(await _mediator.Send(new GetProductById { ProductId = id, CurrencyCode = currencyCode }));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts([FromQuery] string currencyCode)
        {
            return Ok(await _mediator.Send(new GetAllProducts { CurrencyCode = currencyCode }));
        }

        [HttpGet]
        public async Task<ActionResult<IPaginatedList<ProductDto>>> GetPaginatedProducts(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string currencyCode) 
        {
            var products = await _mediator.Send(new GetProductsPaginated { 
                PageNumber = pageNumber, PageSize = pageSize, CurrencyCode = currencyCode
            });

            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<IPaginatedList<ProductDto>>> GetPaginatedProductsByCategory(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string currencyCode,
            [FromQuery] Guid categoryId) 
        {
            var products = await _mediator.Send(new GetProductsPaginatedByCategory { 
                PageNumber = pageNumber, PageSize = pageSize, CurrencyCode = currencyCode, CategoryId = categoryId
            });

            return Ok(products);
        }
    }
}