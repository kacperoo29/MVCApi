using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllOrders : IRequest<IEnumerable<Order>>
    {

        public class Handler : IRequestHandler<GetAllOrders, IEnumerable<Order>>
        {
            private readonly IDomainRepository<Order> _orderRepository;

            public Handler(IDomainRepository<Order> orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<IEnumerable<Order>> Handle(GetAllOrders request, CancellationToken cancellationToken)
            {
                return await _orderRepository.GetAllAsync();
            }
        }
    }
}