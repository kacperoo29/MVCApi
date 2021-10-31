using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.DTOs;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetAllCategories : IRequest<IEnumerable<CategoryDTO>>
    {

        public class Handler : IRequestHandler<GetAllCategories, IEnumerable<CategoryDTO>>
        {
            private readonly IDomainRepository<Category> _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<Category> categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategories request, CancellationToken cancellationToken)
            {
                var categories = await _categoryRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            }
        }
    }
}