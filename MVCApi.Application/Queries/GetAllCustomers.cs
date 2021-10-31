using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllCustomers : IRequest<IEnumerable<CustomerDto>>
    {
        public class Handler : IRequestHandler<GetAllCustomers, IEnumerable<CustomerDto>>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<Customer> _repository;

            public Handler(IDomainRepository<Customer> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomers request,
                CancellationToken cancellationToken)
            {
                var customers = await _repository.GetAllAsync();

                return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
            }
        }
    }
}