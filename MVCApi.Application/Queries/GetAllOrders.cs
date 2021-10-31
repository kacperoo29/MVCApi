using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllOrders : IRequest<IEnumerable<OrderDto>>
    {
        public class Handler : IRequestHandler<GetAllOrders, IEnumerable<OrderDto>>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<Order> _orderRepository;

            public Handler(IDomainRepository<Order> orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<OrderDto>> Handle(GetAllOrders request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
            }
        }
    }
}