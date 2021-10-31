using System.Collections.Generic;

namespace MVCApi.Application.Dto
{
    public class ShoppingCartDto
    {
        public ICollection<ProductCartDto> Products { get; set; }
    }
}