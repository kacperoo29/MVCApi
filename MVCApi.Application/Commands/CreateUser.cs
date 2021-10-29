using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class CreateUser : IRequest<Guid>
    {
        public Guid CustomerId { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }

        public class Handler : IRequestHandler<CreateUser, Guid>
        {
            private readonly IDomainRepository<Customer> _repository;
            private readonly IUserService _userService;

            public Handler(IDomainRepository<Customer> repository, IUserService userService)
            {
                _repository = repository;
                _userService = userService;
            }

            public async Task<Guid> Handle(CreateUser request, CancellationToken cancellationToken)
               {            
                var customer = await _repository.GetByIdAsync(request.CustomerId);
                var user = await _userService.CreateUser(customer, request.UserName, request.Password);
                customer.SetReference(user);                

                return await _repository.Edit(customer);
            }
        }
    }
}