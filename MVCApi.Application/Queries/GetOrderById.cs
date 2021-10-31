using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.DTOs;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetOrderById : IRequest<OrderDTO>
    {
        public Guid OrderId { get; init; }

        public class Handler : IRequestHandler<GetOrderById, OrderDTO>
        {
            private readonly IDomainRepository<Order> _orderRepository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Order> orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<OrderDTO> Handle(GetOrderById request, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.GetByIdAsync(request.OrderId);

                return _mapper.Map<Order, OrderDTO>(order);
            }
        }
    }
}
