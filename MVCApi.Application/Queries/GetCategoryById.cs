using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVCApi.Application.Queries
{
    public class GetCategoryById : IRequest<Category>
    {
        public Guid CategoryId { get; init; }

        public class Handler : IRequestHandler<GetCategoryById, Category>
        {
            private readonly IDomainRepository<Category> _categoryRepository;

            public Handler(IDomainRepository<Category> categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<Category> Handle(GetCategoryById request, CancellationToken cancellationToken)
            {
                return await _categoryRepository.GetByIdAsync(request.CategoryId);
            }
        }
    }
}