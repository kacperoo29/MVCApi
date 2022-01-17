using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MVCApi.Application.Dto;
using MVCApi.Domain;
using MVCApi.Domain.Consts;
using MVCApi.Domain.Entites;

namespace MVCApi.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactInfo, ContactInfoDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Currency, CurrencyDto>();
            CreateMap<CurrencyProduct, CurrencyProductDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.Price, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                    var currencyCode = context.Items["currencyCode"] as string;
                    CurrencyProduct currency;
                    if (currencyCode == null)
                    {
                        currency = src.Prices.FirstOrDefault(x => x.Currency.Code == EShopConsts.DefaultCurrency);
                        currencyCode = EShopConsts.DefaultCurrency;
                    }
                    else
                    {
                        currency = src.Prices.FirstOrDefault(x => x.Currency.Code == currencyCode);
                    }

                    if (currency == null)
                    {
                        var service = context.Items["currencyService"] as ICurrencyService;
                        if (service == null)
                            throw new Exception("Invalid currency service");

                        currency = service.AddConversion(src, currencyCode).GetAwaiter().GetResult();
                    }

                    return new CurrencyProductDto
                    {
                        Value = currency.Value,
                        Currency = new CurrencyDto
                        {
                            Code = currency.Currency.Code,
                            DecimalPlaces = currency.Currency.DecimalPlaces
                        }
                    };
                }));
            CreateMap<ProductCart, ProductCartDto>();
            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<Order, OrderDto>();
            CreateMap(typeof(IPaginatedList<>), typeof(IPaginatedList<>)).ConvertUsing(typeof(PaginatedListMapping<,>));
            CreateMap<IApplicationUser, ApplicationUserDto>()
                .ForMember(d => d.DomainUserId, o => o.MapFrom(s => s.DomainUser.Id));
        }
        private class PaginatedListMapping<TSource, TDestination>
            : ITypeConverter<IPaginatedList<TSource>, IPaginatedList<TDestination>>
        {
            private readonly IMapper _mapper;
            public PaginatedListMapping(IMapper mapper)
            {
                _mapper = mapper;
            }

            public IPaginatedList<TDestination> Convert(IPaginatedList<TSource> source, IPaginatedList<TDestination> destination, ResolutionContext context)
            {
                var list = _mapper.Map<IEnumerable<TSource>, List<TDestination>>(source.Items, opt =>
                {
                    opt.Items["currencyCode"] = context.Items["currencyCode"];
                    opt.Items["currencyService"] = context.Items["currencyService"];
                });

                return new PaginatedList<TDestination>(list, list.Count, source.PageIndex, source.PageSize, source.TotalPages);
            }
        }
    }
}