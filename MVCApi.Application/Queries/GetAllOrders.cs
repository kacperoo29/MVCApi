using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.DTOs;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllOrders : IRequest<IEnumerable<OrderDTO>>
    {

        public class Handler : IRequestHandler<GetAllOrders, IEnumerable<OrderDTO>>
        {
            private readonly IDomainRepository<Order> _orderRepository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Order> orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<OrderDTO>> Handle(GetAllOrders request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);
            }
        }
    }
}