using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.DTOs;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetCategoryById : IRequest<CategoryDTO>
    {
        public Guid CategoryId { get; init; }

        public class Handler : IRequestHandler<GetCategoryById, CategoryDTO>
        {
            private readonly IDomainRepository<Category> _categoryRepository;
            private readonly IMapper _mapper;
            
            public Handler(IDomainRepository<Category> categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<CategoryDTO> Handle(GetCategoryById request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

                return _mapper.Map<Category, CategoryDTO>(category);
            }
        }
    }
}