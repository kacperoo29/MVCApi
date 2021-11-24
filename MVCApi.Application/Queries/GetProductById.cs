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
    public class GetProductById : IRequest<ProductDto>
    {
        public Guid ProductId { get; init; }
        public string CurrencyCode { get; init; }

        public class Handler : IRequestHandler<GetProductById, ProductDto>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<Product> _repository;
            private readonly ICurrencyService _currencyService;

            public Handler(IDomainRepository<Product> repository, IMapper mapper, ICurrencyService currencyService)
            {
                _repository = repository;
                _mapper = mapper;
                _currencyService = currencyService;
            }

            public async Task<ProductDto> Handle(GetProductById request, CancellationToken cancellationToken)
            {
                var product = await _repository.GetByIdAsync(request.ProductId);
                return _mapper.Map<Product, ProductDto>(product, opt =>
                {
                    opt.Items["currencyCode"] = request.CurrencyCode;
                    opt.Items["currencyService"] = _currencyService;
                });
            }
        }
    }
}