using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MVCApi.Controllers 
{
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) {
            _mediator = mediator;
        }

                

    }
}