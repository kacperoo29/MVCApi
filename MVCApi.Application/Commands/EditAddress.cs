using System;
using System.Threading;
using System.Threading.Tasks;
using MVCApi.Domain;
using MVCApi.Domain.Entites;
using MediatR;

namespace MVCApi.Application.Commands
{
    public class EditAddress : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostCode { get; set; }

        public class Handler : IRequestHandler<EditAddress, Guid>
        {
            private readonly IDomainRepository<Address> _addressRepository;

            public Handler(IDomainRepository<Address> addressRepository)
            {
                _addressRepository = addressRepository;
            }

            public async Task<Guid> Handle(EditAddress request, CancellationToken cancellationToken)
            {
                var address = await _addressRepository.GetByIdAsync(request.Id);
                
                if (address == null)
                {
                    return default;
                }
                else
                {
                    address.ChangeCountry(request.Country);
                    address.ChangeCity(request.City);
                    address.ChangeStreet(request.Street);
                    address.ChangeStreetNumber(request.StreetNumber);
                    address.ChangePostCode(request.PostCode);

                    return await _addressRepository.EditAsync(address);
                }
            }
        }
    }
}