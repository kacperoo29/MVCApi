using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetOrderById : IRequest<Order>
    {
        public Guid OrderId { get; init; }

        public class Handler : IRequestHandler<GetOrderById, Order>
        {
            private readonly IDomainRepository<Order> _orderRepository;

            public Handler(IDomainRepository<Order> orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<Order> Handle(GetOrderById request, CancellationToken cancellationToken)
            {
                return await _orderRepository.GetByIdAsync(request.OrderId);
            }
        }
    }
}
