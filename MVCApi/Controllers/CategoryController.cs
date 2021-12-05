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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCategory([FromBody] CreateCategory command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSubcategory([FromBody] CreateSubcategory command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            return Ok(await _mediator.Send(new GetAllCategories()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetCategoryById { CategoryId = id }));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetRootCategories()
        {
            return Ok(await _mediator.Send(new GetRootCategories()));
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> AddProductToCategory([FromBody] AddProductToCategory command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetRootCategory([FromQuery] Guid id)
        {
            return Ok(await _mediator.Send(new GetRootCategory { CategoryId = id }));
        }
    }
}