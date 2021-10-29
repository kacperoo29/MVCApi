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
        public string Name { get; private set; }

        public class Handler : IRequestHandler<CreateCustomer, Guid>
        {
            private readonly IDomainRepository<Customer> _repository;

            public Handler(IDomainRepository<Customer> repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(CreateCustomer request, CancellationToken cancellationToken)
            {
                // var customer = Customer.Create();

                // return await _repository.Add(customer);
                throw new NotImplementedException();
            }
        }
    }
}