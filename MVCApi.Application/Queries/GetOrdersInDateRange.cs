using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetOrdersInDateRange : IRequest<IEnumerable<OrderDto>>
    {
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public string CurrencyCode { get; init; }

        public class Handler : IRequestHandler<GetOrdersInDateRange, IEnumerable<OrderDto>>
        {
            private readonly IDomainRepository<Order> _repository;
            private readonly IMapper _mapper;
            private readonly ICurrencyService _currencyService;

            public Handler(IDomainRepository<Order> repository, IMapper mapper, ICurrencyService currencyService)
            {
                _repository = repository;
                _mapper = mapper;
                _currencyService = currencyService;
            }

            public async Task<IEnumerable<OrderDto>> Handle(GetOrdersInDateRange request, CancellationToken cancellationToken)
            {
                var orders = await _repository.GetAllAsync(x => x.DateCreated >= request.StartDate && x.DateCreated <= request.EndDate);

                return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders, opt =>
                {
                    opt.Items["currencyCode"] = request.CurrencyCode;
                    opt.Items["currencyService"] = _currencyService;
                });
            }
        }
    }
}