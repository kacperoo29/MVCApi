using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class LinkCustomer : IRequest<Guid>
    {
        public Guid UserId { get; init; }
        public Guid CustomerId { get; init;}

        public class Handler : IRequestHandler<LinkCustomer, Guid>
        {
            private readonly IUserService _userService;
            private readonly IDomainRepository<Customer> _repository;

            public Handler(IUserService userService, IDomainRepository<Customer> repository)
            {
                _userService = userService;
                _repository = repository;
            }

            public async Task<Guid> Handle(LinkCustomer request, CancellationToken cancellationToken)
            {
               var customer = await _repository.GetByIdAsync(request.CustomerId);

                return await _userService.LinkDomainUser<Customer>(request.UserId, customer);
            }
        }
    }
}