using System;
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
    public class GetProductsPaginatedByCategory : IRequest<IPaginatedList<ProductDto>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public string CurrencyCode { get; init; }
        public Guid CategoryId { get; init; }

        public class Handler : IRequestHandler<GetProductsPaginatedByCategory, IPaginatedList<ProductDto>>
        {
            private readonly IMapper _mapper;
            private readonly IDomainRepository<Product> _productRepository;
            private readonly ICurrencyService _currencyService;
            private readonly IDomainRepository<Category> _categoryRepository;

            public Handler(
                IDomainRepository<Product> productRepository,
                IMapper mapper,
                ICurrencyService currencyService,
                IDomainRepository<Category> categoryRepository)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _currencyService = currencyService;
                _categoryRepository = categoryRepository;
            }

            public async Task<IPaginatedList<ProductDto>> Handle(GetProductsPaginatedByCategory request, CancellationToken cancellationToken)
            {
                var query = $@"WITH RecursiveCategories(Id, ParentId)
                  AS
                  (
                      SELECT Id, ParentId
                      FROM dbo.Categories
                      WHERE Id = '{request.CategoryId}'
                      UNION ALL
                      SELECT c1.Id, c1.ParentId
                      FROM RecursiveCategories AS s
                      INNER JOIN dbo.Categories AS c1 ON c1.ParentId = s.Id
                  )
                  SELECT p.*
                  FROM RecursiveCategories AS c
                  INNER JOIN dbo.CategoryProduct AS cp on cp.CategoriesId = c.Id
                  INNER JOIN dbo.Products AS p on p.Id = cp.ProductsId 
                  ORDER BY p.Id
                  OFFSET {(request.PageNumber - 1) * request.PageSize} ROWS
                  FETCH NEXT {request.PageSize} ROWS ONLY";

                var products = await _productRepository.SqlQueryPaginated(query, request.PageNumber, request.PageSize);

                return _mapper.Map<IPaginatedList<Product>, IPaginatedList<ProductDto>>(products, opt =>
                {
                    opt.Items["currencyCode"] = request.CurrencyCode;
                    opt.Items["currencyService"] = _currencyService;
                });
            }
        }
    }
}