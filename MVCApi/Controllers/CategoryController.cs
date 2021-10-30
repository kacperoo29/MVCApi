using System;
using System.Collections;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return Ok(await _mediator.Send(new GetAllCategories()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetCategoryById { CategoryId = id }));
        }


    }
}