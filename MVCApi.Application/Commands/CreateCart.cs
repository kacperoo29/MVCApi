using System;
using System.Runtime.CompilerServices;
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
            private readonly IDomainRepository<Customer> _customerRepository;
            private readonly IUserService _userService;

            public Handler(
                IDomainRepository<ShoppingCart> cartRepository,
                IDomainRepository<Customer> customerRepository,
                IUserService userService)
            {
                _cartRepository = cartRepository;
                _userService = userService;
            }

            public async Task<Guid> Handle(CreateCart request, CancellationToken cancellationToken)
            {
                var user = await _userService.GetCurrentUser();
                var customer = await _customerRepository.GetByIdAsync(user.Id);
                var cart = ShoppingCart.Create(customer);
                await _cartRepository.Add(cart);
                
                return cart.Id;
            }
        }

    }
}