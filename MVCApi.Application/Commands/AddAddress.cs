using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class AddAddress : IRequest<Guid>
    {
        public Guid CustomerId { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string StreetNumber { get; init; }
        public string PostCode { get; init; }

        public class Handler : IRequestHandler<AddAddress, Guid>
        {
            private readonly IDomainRepository<Customer> _customerRepository;
            private readonly IDomainRepository<Address> _addressRepository;
            private readonly IUserService _userService;

            public Handler(IDomainRepository<Customer> repository, IUserService userService, IDomainRepository<Address> addressRepository)
            {
                _customerRepository = repository;
                _userService = userService;
                _addressRepository = addressRepository;
            }

            public async Task<Guid> Handle(AddAddress request, CancellationToken cancellationToken)
            {
                var currentUser = await _userService.GetCurrentUser();
                var roles = await _userService.GetUserRoles(currentUser.Id);
                if (!roles.Contains("Admin") && currentUser.DomainUser.Id != request.CustomerId)
                    throw new UnauthorizedAccessException();

                var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
                var address = Address.Create(request.Country, request.City, request.Street, request.StreetNumber, request.PostCode);
                await _addressRepository.AddAsync(address);
                
                customer.AddAddress(address);
                await _customerRepository.EditAsync(customer);

                return address.Id;
            }
        }
    }
}