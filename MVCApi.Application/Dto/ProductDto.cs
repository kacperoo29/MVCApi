using System;
using System.Collections.Generic;

namespace MVCApi.Application.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
        public ICollection<CurrencyProductDto> Prices { get; set; }
    }
}