using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class AddProductToCategory : IRequest<Guid>
    {
        public Guid CategoryId { get; init; }
        public Guid ProductId { get; init; }

        public class Handler : IRequestHandler<AddProductToCategory, Guid>
        {
            private readonly IDomainRepository<Product> _productRepository;
            private readonly IDomainRepository<Category> _categoryRepository;

            public Handler(IDomainRepository<Product> productRepository, IDomainRepository<Category> categoryRepository)
            {
                _productRepository = productRepository;
                _categoryRepository = categoryRepository;
            }

            public async Task<Guid> Handle(AddProductToCategory request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
                var product = await _productRepository.GetByIdAsync(request.ProductId);

                category.AddProduct(product);

                return await _categoryRepository.EditAsync(category);
            }
        }
    }
}