using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.DTOs;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetProductById : IRequest<ProductDTO>
    {
        public Guid ProductId { get; init; }

        public class Handler : IRequestHandler<GetProductById, ProductDTO>
        {
            private readonly IDomainRepository<Product> _repository;
            private readonly IMapper _mapper;
            
            public Handler(IDomainRepository<Product> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<ProductDTO> Handle(GetProductById request, CancellationToken cancellationToken)
            {
                var product = await _repository.GetByIdAsync(request.ProductId);
                return _mapper.Map<Product, ProductDTO>(product);
            }
        }
    }
}