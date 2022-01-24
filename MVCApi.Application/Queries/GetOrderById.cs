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
        public string CurrencyCode { get; init; }

        public class Handler : IRequestHandler<GetOrderById, OrderDto>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<Order> _orderRepository;
            private readonly ICurrencyService _currencyService;

            public Handler(IDomainRepository<Order> orderRepository, IMapper mapper, ICurrencyService currencyService)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
                _currencyService = currencyService;
            }

            public async Task<OrderDto> Handle(GetOrderById request, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.GetByIdAsync(request.OrderId);

                return _mapper.Map<Order, OrderDto>(order, opt =>
                {
                    opt.Items["currencyCode"] = request.CurrencyCode;
                    opt.Items["currencyService"] = _currencyService;
                });
            }
        }
    }
}