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
    public class GetCartById : IRequest<ShoppingCart>
    {
        public Guid CartId { get; private set; }

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
