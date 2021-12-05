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
    public class GetContactInfoById : IRequest<ContactInfoDto>
    {
        public Guid ContactInfoId { get; init; }

        public class Handler : IRequestHandler<GetContactInfoById, ContactInfoDto>
        {
            private readonly IDomainRepository<ContactInfo> _contactInfoRepository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<ContactInfo> contactInfoRepository, IMapper mapper)
            {
                _contactInfoRepository = contactInfoRepository;
                _mapper = mapper;
            }

            public async Task<ContactInfoDto> Handle(GetContactInfoById request, CancellationToken cancellationToken)
            {
                var contactInfo = await _contactInfoRepository.GetByIdAsync(request.ContactInfoId);

                return _mapper.Map<ContactInfo, ContactInfoDto>(contactInfo);
            }
        }
    }
}