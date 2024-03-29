﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetCartById : IRequest<ShoppingCartDto>
    {
        public Guid CartId { get; init; }
        public string CurrencyCode { get; init; }

        public class Handler : IRequestHandler<GetCartById, ShoppingCartDto>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<ShoppingCart> _repository;
            private readonly ICurrencyService _currencyService;

            public Handler(IDomainRepository<ShoppingCart> repository, IMapper mapper, ICurrencyService currencyService)
            {
                _repository = repository;
                _mapper = mapper;
                _currencyService = currencyService;
            }

            public async Task<ShoppingCartDto> Handle(GetCartById request, CancellationToken cancellationToken)
            {
                var cart = await _repository.GetByIdAsync(request.CartId);

                return _mapper.Map<ShoppingCart, ShoppingCartDto>(cart, opt =>
                {
                    opt.Items["currencyCode"] = request.CurrencyCode;
                    opt.Items["currencyService"] = _currencyService;
                });
            }
        }
    }
}