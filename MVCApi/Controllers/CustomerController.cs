using System.Collections;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MVCApi.Controllers 
{
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator) {
            _mediator = mediator;
        }        

    }
}