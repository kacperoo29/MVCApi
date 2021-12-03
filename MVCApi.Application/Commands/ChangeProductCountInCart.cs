using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class ChangeProductCountInCart : IRequest<Guid>
    {
        public Guid CartId { get; init; }
        public Guid ProductId { get; init; }
        public int Count { get; init; }

        public class Handler : IRequestHandler<ChangeProductCountInCart, Guid>
        {
            private readonly IDomainRepository<ShoppingCart> _cartRepository;

            public Handler(IDomainRepository<ShoppingCart> cartRepository)
            {
                _cartRepository = cartRepository;
            }

            public async Task<Guid> Handle(ChangeProductCountInCart request, CancellationToken cancellationToken)
            {
                ShoppingCart cart = await _cartRepository.GetByIdAsync(request.CartId);
                cart.ChangeProductCount(request.ProductId, request.Count);

                return await _cartRepository.EditAsync(cart);
            }
        }
    }
}