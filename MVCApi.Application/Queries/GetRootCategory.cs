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
    public class GetRootCategory : IRequest<CategoryDto>
    {
        public Guid CategoryId { get; init; }

        public class Handler : IRequestHandler<GetRootCategory, CategoryDto>
        {
            private readonly IDomainRepository<Category> _repository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Category> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CategoryDto> Handle(GetRootCategory request, CancellationToken cancellationToken)
            {
                var category = await _repository.GetByIdAsync(request.CategoryId);
                do
                {
                    category = category.Parent;
                } while (category.Parent != null);

                return _mapper.Map<Category, CategoryDto>(category);
            }
        }
    }
}