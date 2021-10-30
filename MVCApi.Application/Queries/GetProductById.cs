using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVCApi.Application.Queries
{
    public class GetProductById : IRequest<Product>
    {
        public Guid ProductId { get; private set; }

        public class Handler : IRequestHandler<GetProductById, Product>
        {
            private readonly IDomainRepository<Product> _repository;

            public Handler(IDomainRepository<Product> repository)
            {
                _repository = repository;
            }

            public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
            {
                return await _repository.GetByIdAsync(request.ProductId);
            }
        }
    }
}