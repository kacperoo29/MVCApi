using System;
using System.Collections.Generic;

namespace MVCApi.Application.Dto
{
    public class ShoppingCartDto
    {
        public Guid Id { get; set; }
        public ICollection<ProductCartDto> Products { get; set; }
    }
}