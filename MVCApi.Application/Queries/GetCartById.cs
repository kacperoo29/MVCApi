using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.DTOs;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Application.Queries
{
    public class GetCartById : IRequest<ShoppingCartDTO>
    {
        public Guid CartId { get; init; }

        public class Handler : IRequestHandler<GetCartById, ShoppingCartDTO>
        {
            private readonly IDomainRepository<ShoppingCart> _repository;
            private readonly IMapper _mapper;

            public Handler(IDomainRepository<ShoppingCart> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<ShoppingCartDTO> Handle(GetCartById request, CancellationToken cancellationToken)
            {
                var cart = await _repository.GetByIdAsync(request.CartId);

                return _mapper.Map<ShoppingCart, ShoppingCartDTO>(cart);
            }
        }
    }
}
