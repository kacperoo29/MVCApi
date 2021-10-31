using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class CreateCart : IRequest<Guid>
    {
        public class Handler : IRequestHandler<CreateCart, Guid>
        {
            private readonly IDomainRepository<ShoppingCart> _cartRepository;

            public Handler(IDomainRepository<ShoppingCart> cartRepository)
            {
                _cartRepository = cartRepository;
            }

            public async Task<Guid> Handle(CreateCart request, CancellationToken cancellationToken)
            {
                var cart = ShoppingCart.Create();

                return await _cartRepository.AddAsync(cart);
            }
        }
    }
}