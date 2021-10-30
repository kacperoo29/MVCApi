using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllCategories : IRequest<IEnumerable<Category>>
    {

        public class Handler : IRequestHandler<GetAllCategories, IEnumerable<Category>>
        {
            private readonly IDomainRepository<Category> _categoryRepository;

            public Handler(IDomainRepository<Category> categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<IEnumerable<Category>> Handle(GetAllCategories request, CancellationToken cancellationToken)
            {
                return await _categoryRepository.GetAllAsync();
            }
        }
    }
}