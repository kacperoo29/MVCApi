using System;
using MVCApi.Domain.Enums;

namespace MVCApi.Application.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public CustomerDto Customer { get; set; }
        public ShoppingCartDto ShoppingCart { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime DateCreated { get; set; }
    }
}