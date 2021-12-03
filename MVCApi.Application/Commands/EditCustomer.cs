using System;
using System.Threading;
using System.Threading.Tasks;
using MVCApi.Domain;
using MVCApi.Domain.Entites;
using MediatR;

namespace MVCApi.Application.Commands
{
    public class EditCustomer : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
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

        public class Handler : IRequestHandler<EditCustomer, Guid>
        {
            private readonly IDomainRepository<Customer> _customerRepository;

            public Handler(IDomainRepository<Customer> customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<Guid> Handle(EditCustomer request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
                
                if (customer == null)
                {
                    return default;
                }
                else
                {
                    customer.ChangeFirstName(request.FirstName);
                    customer.ChangeLastName(request.LastName);
                    customer.ChangeDateOfBirth(request.DateOfBirth);
                    
                    var address = Address.Create(request.Country, request.City, request.Street, request.StreetNumber,
                    request.PostCode);
                    var contactInfo = ContactInfo.Create(request.Email, request.PhoneNumber);

                    customer.ChangeAddress(address);
                    customer.ChangeContactInfo(contactInfo);

                    return await _customerRepository.EditAsync(customer);
                }
            }
        }
    }
}