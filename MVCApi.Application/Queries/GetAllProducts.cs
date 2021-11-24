using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllProducts : IRequest<IEnumerable<ProductDto>>
    {
        public string CurrencyCode { get; init; }

        public class Handler : IRequestHandler<GetAllProducts, IEnumerable<ProductDto>>
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

            public async Task<IEnumerable<ProductDto>> Handle(GetAllProducts request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(product, opt =>
                {
                    opt.Items["currencyCode"] = request.CurrencyCode;
                    opt.Items["currencyService"] = _currencyService;
                });
            }
        }
    }
}