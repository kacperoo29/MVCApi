using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetCustomerById : IRequest<Customer>
    {
        public Guid CustomerId { get; init; }

        public class Handler : IRequestHandler<GetCustomerById, Customer>
        {
            private readonly IDomainRepository<Customer> _repository;

            public Handler(IDomainRepository<Customer> repository)
            {
                _repository = repository;
            }

            public async Task<Customer> Handle(GetCustomerById request, CancellationToken cancellationToken)
            {
                return await _repository.GetByIdAsync(request.CustomerId);
            }
        }
    }
}
