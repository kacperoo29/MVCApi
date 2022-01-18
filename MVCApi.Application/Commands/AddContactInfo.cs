using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class AddContactInfo : IRequest<Guid>
    {
        public Guid CustomerId { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }

        public class Handler : IRequestHandler<AddContactInfo, Guid>
        {
            private readonly IDomainRepository<Customer> _customerRepository;
            private readonly IDomainRepository<ContactInfo> _contactInfoRepository;
            private readonly IUserService _userService;

            public Handler(IDomainRepository<Customer> repository, IUserService userService, IDomainRepository<ContactInfo> contactInfoRepository)
            {
                _customerRepository = repository;
                _userService = userService;
                _contactInfoRepository = contactInfoRepository;
            }

            public async Task<Guid> Handle(AddContactInfo request, CancellationToken cancellationToken)
            {
                var currentUser = await _userService.GetCurrentUser();
                var roles = await _userService.GetUserRoles(currentUser.Id);
                if (!roles.Contains("Admin") && currentUser.DomainUser.Id != request.CustomerId)
                    throw new UnauthorizedAccessException();

                var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
                var contactInfo = ContactInfo.Create(request.Email, request.PhoneNumber);
                await _contactInfoRepository.AddAsync(contactInfo);

                customer.AddContactInfo(contactInfo);
                await _customerRepository.EditAsync(customer);

                return contactInfo.Id;
            }
        }
    }
}