using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllCustomers : IRequest<IEnumerable<Customer>>
    {

        public class Handler : IRequestHandler<GetAllCustomers, IEnumerable<Customer>>
        {
            private readonly IDomainRepository<Customer> _repository;

            public Handler(IDomainRepository<Customer> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Customer>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
            {
                return await _repository.GetAllAsync();
            }
        }
    }
}
