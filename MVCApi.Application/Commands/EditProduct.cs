using System;
using System.Threading;
using System.Threading.Tasks;
using MVCApi.Domain;
using MVCApi.Domain.Entites;
using MediatR;

namespace MVCApi.Application.Commands
{
    public class EditProduct : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public class Handler : IRequestHandler<EditProduct, Guid>
        {
            private readonly IDomainRepository<Product> _productRepository;

            public Handler(IDomainRepository<Product> productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<Guid> Handle(EditProduct request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(request.ProductId);
                
                if (product == null)
                {
                    return default;
                }
                else
                {
                    product.ChangeName(request.Name);
                    product.ChangeDescription(request.Description);
                    product.ChangeImage(request.Image);

                    return await _productRepository.EditAsync(product);
                }
            }
        }
    }
}