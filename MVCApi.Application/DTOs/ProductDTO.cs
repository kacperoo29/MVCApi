using System.Collections.Generic;

namespace MVCApi.Application.DTOs
{
    public class ProductDTO
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public CategoryDTO Category { get; private set; }
        public ICollection<CurrencyDTO> Prices { get; private set; }
    }
}