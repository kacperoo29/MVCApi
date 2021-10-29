using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetCartById : IRequest<ShoppingCart>
    {
        public Guid CartId { get; init; }

        public class Handler : IRequestHandler<GetCartById, ShoppingCart>
        {
            private readonly IDomainRepository<ShoppingCart> _repository;

            public Handler(IDomainRepository<ShoppingCart> repository)
            {
                _repository = repository;
            }

            public async Task<ShoppingCart> Handle(GetCartById request, CancellationToken cancellationToken)
            {
                return await _repository.GetByIdAsync(request.CartId);
            }
        }
    }
}
