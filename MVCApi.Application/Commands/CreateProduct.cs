using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class CreateProduct : IRequest<Guid>
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public class Handler : IRequestHandler<CreateProduct, Guid>
        {
            private readonly IDomainRepository<Product> _productRepository;

            public Handler(IDomainRepository<Product> productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<Guid> Handle(CreateProduct request, CancellationToken cancellationToken)
            {
                var product = Product.Create(request.Name, request.Description);

                return await _productRepository.AddAsync(product);

            }
        }
    }
}