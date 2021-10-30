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
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public string PostCode { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public class Handler : IRequestHandler<CreateCustomer, Guid>
        {
            private readonly IDomainRepository<Customer> _customerRepository;
            private readonly IDomainRepository<Address> _addressRepository;
            private readonly IDomainRepository<ContactInfo> _contactRepository;

            public Handler(IDomainRepository<Customer> customerRepository, IDomainRepository<Address> addressRepository, IDomainRepository<ContactInfo> contactRepository)
            {
                _customerRepository = customerRepository;
                _addressRepository = addressRepository;
                _contactRepository = contactRepository;
            }

            public async Task<Guid> Handle(CreateCustomer request, CancellationToken cancellationToken)
            {
                var address = Address.Create(request.Country, request.City, request.Street, request.StreetNumber, request.PostCode);
                var contactInfo = ContactInfo.Create(request.Email, request.PhoneNumber);
                var customer = Customer.Create(request.FirstName, request.LastName, request.DateOfBirth, address, contactInfo);
                contactInfo.LinkCustomer(customer);

                await _addressRepository.AddAsync(address);
                await _contactRepository.AddAsync(contactInfo);

                return await _customerRepository.AddAsync(customer);
            }
        }
    }
}