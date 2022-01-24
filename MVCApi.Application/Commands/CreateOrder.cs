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
        public Guid AddressId { get; init; }
        public Guid ContactInfoId { get; init; }

        public class Handler : IRequestHandler<CreateOrder, Guid>
        {
            private readonly IDomainRepository<ShoppingCart> _cartRepository;
            private readonly IDomainRepository<Customer> _customerRepository;
            private readonly IDomainRepository<Order> _orderRepository;
            private readonly IDomainRepository<Address> _addressRepository;
            private readonly IDomainRepository<ContactInfo> _contactInfoRepository;

            public Handler(IDomainRepository<Order> orderRepository, IDomainRepository<ShoppingCart> cartRepository,
                IDomainRepository<Customer> customerRepository, IDomainRepository<Address> addressRepository, IDomainRepository<ContactInfo> contactInfoRepository)
            {
                _orderRepository = orderRepository;
                _cartRepository = cartRepository;
                _customerRepository = customerRepository;
                _addressRepository = addressRepository;
                _contactInfoRepository = contactInfoRepository;
            }

            public async Task<Guid> Handle(CreateOrder request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
                var cart = await _cartRepository.GetByIdAsync(request.CartId);
                var address = await _addressRepository.GetByIdAsync(request.AddressId);
                var contactInfo = await _contactInfoRepository.GetByIdAsync(request.ContactInfoId);
                var order = Order.Create(customer, cart, address, contactInfo);

                return await _orderRepository.AddAsync(order);
            }
        }
    }
}