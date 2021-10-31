using AutoMapper;
using MVCApi.Application.Dto;
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
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCart, ProductCartDto>();
            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<Order, OrderDto>();
        }
    }
}