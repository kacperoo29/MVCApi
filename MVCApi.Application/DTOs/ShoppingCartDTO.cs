using System.Collections.Generic;

namespace MVCApi.Application.DTOs
{
    public class ShoppingCartDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
    }
}