using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper;
using MVCApi.Application.Dto;
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
        }
    }
}