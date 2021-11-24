using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Consts;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class CreateProduct : IRequest<Guid>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Image { get; init; }
        public decimal Price { get; init; }

        public class Handler : IRequestHandler<CreateProduct, Guid>
        {
            private readonly IDomainRepository<Product> _productRepository;
            private readonly IDomainRepository<Currency> _currencyRepository;

            public Handler(IDomainRepository<Product> productRepository, IDomainRepository<Currency> currencyRepository)
            {
                _productRepository = productRepository;
                _currencyRepository = currencyRepository;
            }

            public async Task<Guid> Handle(CreateProduct request, CancellationToken cancellationToken)
            {
                var currency = (await _currencyRepository.GetAllAsync(x => x.Code == EShopConsts.DefaultCurrency)).First();
                var product = Product.Create(request.Name, request.Description, request.Image, request.Price, currency);

                return await _productRepository.AddAsync(product);
            }
        }
    }
}