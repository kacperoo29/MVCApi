using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetOrderById : IRequest<OrderDto>
    {
        public Guid OrderId { get; init; }

        public class Handler : IRequestHandler<GetOrderById, OrderDto>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<Order> _orderRepository;

            public Handler(IDomainRepository<Order> orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<OrderDto> Handle(GetOrderById request, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.GetByIdAsync(request.OrderId);

                return _mapper.Map<Order, OrderDto>(order);
            }
        }
    }
}