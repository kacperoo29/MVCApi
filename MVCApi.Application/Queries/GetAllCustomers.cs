using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.DTOs;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllCustomers : IRequest<IEnumerable<CustomerDTO>>
    {

        public class Handler : IRequestHandler<GetAllCustomers, IEnumerable<CustomerDTO>>
        {
            private readonly IDomainRepository<Customer> _repository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Customer> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<CustomerDTO>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
            {
                var customers = await _repository.GetAllAsync();

                return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);
            }
        }
    }
}
