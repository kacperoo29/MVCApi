using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class CreateOrder : IRequest<Guid>
    {
        public Guid CartId { get; init; }
        public Guid CustomerId { get; init; }

        public class Handler : IRequestHandler<CreateOrder, Guid>
        {
            private readonly IDomainRepository<ShoppingCart> _cartRepository;
            private readonly IDomainRepository<Customer> _customerRepository;
            private readonly IDomainRepository<Order> _orderRepository;

            public Handler(IDomainRepository<Order> orderRepository, IDomainRepository<ShoppingCart> cartRepository,
                IDomainRepository<Customer> customerRepository)
            {
                _orderRepository = orderRepository;
                _cartRepository = cartRepository;
                _customerRepository = customerRepository;
            }

            public async Task<Guid> Handle(CreateOrder request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
                var cart = await _cartRepository.GetByIdAsync(request.CartId);
                var order = Order.Create(customer, cart);

                return await _orderRepository.AddAsync(order);
            }
        }
    }
}