using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class CreateCategory : IRequest<Guid>
    {
        public string Name { get; init; }

        public class Handler : IRequestHandler<CreateCategory, Guid>
        {
            private readonly IDomainRepository<Category> _categoryRepository;

            public Handler(IDomainRepository<Category> categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<Guid> Handle(CreateCategory request, CancellationToken cancellationToken)
            {
                var category = Category.Create(request.Name);

                return await _categoryRepository.AddAsync(category);
            }
        }
    }
}