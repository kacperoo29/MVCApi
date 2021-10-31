using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class CreateCustomer : IRequest<Guid>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string StreetNumber { get; init; }
        public string PostCode { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }

        public class Handler : IRequestHandler<CreateCustomer, Guid>
        {
            private readonly IDomainRepository<Customer> _customerRepository;

            public Handler(IDomainRepository<Customer> customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<Guid> Handle(CreateCustomer request, CancellationToken cancellationToken)
            {
                var address = Address.Create(request.Country, request.City, request.Street, request.StreetNumber,
                    request.PostCode);
                var contactInfo = ContactInfo.Create(request.Email, request.PhoneNumber);
                var customer = Customer.Create(request.FirstName, request.LastName, request.DateOfBirth, address,
                    contactInfo);

                return await _customerRepository.AddAsync(customer);
            }
        }
    }
}