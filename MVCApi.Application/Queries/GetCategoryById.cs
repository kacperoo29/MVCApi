using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetCategoryById : IRequest<CategoryDto>
    {
        public Guid CategoryId { get; init; }

        public class Handler : IRequestHandler<GetCategoryById, CategoryDto>
        {
            private readonly IDomainRepository<Category> _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Category> categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<CategoryDto> Handle(GetCategoryById request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

                return _mapper.Map<Category, CategoryDto>(category);
            }
        }
    }
}