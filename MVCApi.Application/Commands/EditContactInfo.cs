using System;
using System.Threading;
using System.Threading.Tasks;
using MVCApi.Domain;
using MVCApi.Domain.Entites;
using MediatR;

namespace MVCApi.Application.Commands
{
    public class EditContactInfo : IRequest<Guid>
    {
        public Guid ContactInfoId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public class Handler : IRequestHandler<EditContactInfo, Guid>
        {
            private readonly IDomainRepository<ContactInfo> _contactInfoRepository;

            public Handler(IDomainRepository<ContactInfo> contactInfoRepository)
            {
                _contactInfoRepository = contactInfoRepository;
            }

            public async Task<Guid> Handle(EditContactInfo request, CancellationToken cancellationToken)
            {
                var contactInfo = await _contactInfoRepository.GetByIdAsync(request.ContactInfoId);
                
                if (contactInfo == null)
                {
                    return default;
                }
                else
                {
                    contactInfo.ChangeEmail(request.Email);
                    contactInfo.ChangePhoneNumber(request.PhoneNumber);

                    return await _contactInfoRepository.EditAsync(contactInfo);
                }
            }
        }
    }
}