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
    public class GetAllProducts : IRequest<IEnumerable<ProductDto>>
    {
        public class Handler : IRequestHandler<GetAllProducts, IEnumerable<ProductDto>>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<Product> _productRepository;

            public Handler(IDomainRepository<Product> productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ProductDto>> Handle(GetAllProducts request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(product);
            }
        }
    }
}