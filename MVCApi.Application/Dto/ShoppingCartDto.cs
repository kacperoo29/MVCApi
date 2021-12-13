using System;
using System.Collections.Generic;
using MVCApi.Domain.Enums;

namespace MVCApi.Application.Dto
{
    public class ShoppingCartDto
    {
        public Guid Id { get; set; }
        public ICollection<ProductCartDto> Products { get; set; }
        public ShoppingCartState State { get; set; }
    }
}