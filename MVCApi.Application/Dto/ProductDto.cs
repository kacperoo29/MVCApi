using System.Collections.Generic;

namespace MVCApi.Application.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<CurrencyProductDto> Prices { get; set; }
    }
}