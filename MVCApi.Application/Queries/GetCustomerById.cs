using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetCustomerById : IRequest<CustomerDto>
    {
        public Guid CustomerId { get; init; }

        public class Handler : IRequestHandler<GetCustomerById, CustomerDto>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<Customer> _repository;

            public Handler(IDomainRepository<Customer> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(GetCustomerById request, CancellationToken cancellationToken)
            {
                var customer = await _repository.GetByIdAsync(request.CustomerId);

                return _mapper.Map<Customer, CustomerDto>(customer);
            }
        }
    }
}