using AutoMapper;
using MVCApi.Application.DTOs;
using MVCApi.Domain.Entites;

namespace MVCApi.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactInfo, ContactInfoDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Currency, CurrencyDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ShoppingCart, ShoppingCartDTO>();
            CreateMap<Order, OrderDTO>();
        }
    }
}