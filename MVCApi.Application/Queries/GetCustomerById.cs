using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.DTOs;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetCustomerById : IRequest<CustomerDTO>
    {
        public Guid CustomerId { get; init; }

        public class Handler : IRequestHandler<GetCustomerById, CustomerDTO>
        {
            private readonly IDomainRepository<Customer> _repository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Customer> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CustomerDTO> Handle(GetCustomerById request, CancellationToken cancellationToken)
            {     
                var customer = await _repository.GetByIdAsync(request.CustomerId);

                return _mapper.Map<Customer, CustomerDTO>(customer);
            }
        }
    }
}
