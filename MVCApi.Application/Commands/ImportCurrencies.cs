using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class ImportCurrencies : IRequest<IEnumerable<Guid>>
    {
        public IEnumerable<CurrencyDto> Currencies { get; init; }

        public class Handler : IRequestHandler<ImportCurrencies, IEnumerable<Guid>>
        {
            private readonly IDomainRepository<Currency> _repository;

            public Handler(IDomainRepository<Currency> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Guid>> Handle(ImportCurrencies request, CancellationToken cancellationToken)
            {
                var ids = new List<Guid>();
                foreach (var currency in request.Currencies)
                {
                    var id = await _repository.AddAsync(Currency.Create(currency.Code, currency.DecimalPlaces));
                    ids.Add(id);
                }

                return ids.AsEnumerable();
            }
        }
    }
}