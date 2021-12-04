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
    public class GetProductsPaginated : IRequest<IPaginatedList<ProductDto>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public string CurrencyCode { get; init; }

        public class Handler : IRequestHandler<GetProductsPaginated, IPaginatedList<ProductDto>>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<Product> _productRepository;
            private readonly ICurrencyService _currencyService;

            public Handler(IDomainRepository<Product> productRepository, IMapper mapper, ICurrencyService currencyService)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _currencyService = currencyService;
            }
            
            public async Task<IPaginatedList<ProductDto>> Handle(GetProductsPaginated request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

                return _mapper.Map<IPaginatedList<Product>, IPaginatedList<ProductDto>>(product, opt =>
                {
                    opt.Items["currencyCode"] = request.CurrencyCode;
                    opt.Items["currencyService"] = _currencyService;
                });
            }
        }
    }
}