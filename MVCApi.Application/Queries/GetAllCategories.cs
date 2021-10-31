using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllCategories : IRequest<IEnumerable<CategoryDto>>
    {
        public class Handler : IRequestHandler<GetAllCategories, IEnumerable<CategoryDto>>
        {
            private readonly IDomainRepository<Category> _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Category> categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategories request,
                CancellationToken cancellationToken)
            {
                var categories = await _categoryRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
            }
        }
    }
}