using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class RemoveProductFromCart : IRequest<Guid>
    {
        public Guid CartId { get; init; }
        public Guid ProductId { get; init; }

        public class Handler : IRequestHandler<RemoveProductFromCart, Guid>
        {
            private readonly IDomainRepository<ShoppingCart> _cartRepository;

            public Handler(IDomainRepository<ShoppingCart> cartRepository)
            {
                _cartRepository = cartRepository;
            }
            
            public async Task<Guid> Handle(RemoveProductFromCart request, CancellationToken cancellationToken)
            {
                var cart = await _cartRepository.GetByIdAsync(request.CartId);
                cart.RemoveProduct(request.ProductId);

                return await _cartRepository.EditAsync(cart);
            }
        }
    }
}