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
    public class GetAddressById : IRequest<AddressDto>
    {
        public Guid AddressId { get; init; }

        public class Handler : IRequestHandler<GetAddressById, AddressDto>
        {
            private readonly IDomainRepository<Address> _addressRepository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Address> addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }

            public async Task<AddressDto> Handle(GetAddressById request, CancellationToken cancellationToken)
            {
                var address = await _addressRepository.GetByIdAsync(request.AddressId);

                return _mapper.Map<Address, AddressDto>(address);
            }
        }
    }
}