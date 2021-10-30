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
        public string Name { get; private set; }

        public class Handler : IRequestHandler<CreateProduct, Guid>
        {
            private readonly IDomainRepository<Product> _repository;

            public Handler(IDomainRepository<Product> repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(CreateProduct request, CancellationToken cancellationToken)
            {
                //TODO: implement name as a parameter
                var product = Product.Create("test");

                return await _repository.Add(product);

            }
        }
    }
}