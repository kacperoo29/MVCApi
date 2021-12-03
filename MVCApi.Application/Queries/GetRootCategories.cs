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
    public class GetRootCategories : IRequest<IEnumerable<CategoryDto>>
    {
        public class Handler : IRequestHandler<GetRootCategories, IEnumerable<CategoryDto>>
        {
            private readonly IDomainRepository<Category> _repository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Category> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<CategoryDto>> Handle(GetRootCategories request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(await _repository.GetAllAsync(x => x.Parent == null));
            }
        }
    }
}