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
        public string CurrencyCode { get; init; }

        public class Handler : IRequestHandler<GetAllOrders, IEnumerable<OrderDto>>
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

            public async Task<IEnumerable<OrderDto>> Handle(GetAllOrders request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders, opt =>
                {
                    opt.Items["currencyCode"] = request.CurrencyCode;
                    opt.Items["currencyService"] = _currencyService;
                });
            }
        }
    }
}