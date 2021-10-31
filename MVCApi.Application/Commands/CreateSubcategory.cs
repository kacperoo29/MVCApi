using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Commands
{
    public class CreateSubcategory : IRequest<Guid>
    {
        public string Name { get; init; }
        public Guid ParentId { get; init; }

        public class Handler : IRequestHandler<CreateSubcategory, Guid>
        {
            private readonly IDomainRepository<Category> _categoryRepository;

            public Handler(IDomainRepository<Category> categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<Guid> Handle(CreateSubcategory request, CancellationToken cancellationToken)
            {
                var parent = await _categoryRepository.GetByIdAsync(request.ParentId);
                var category = Category.Create(request.Name, parent);

                return await _categoryRepository.AddAsync(category);
            }
        }
    }
}