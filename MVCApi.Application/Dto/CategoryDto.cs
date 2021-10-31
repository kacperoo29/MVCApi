using System.Collections.Generic;

namespace MVCApi.Application.Dto
{
    public class CategoryDto
    {
        public string Name { get; private set; }
        public virtual CategoryDto Parent { get; private set; }
        public virtual ICollection<CategoryDto> Children { get; private set; }
        public virtual ICollection<ProductDto> Products { get; private set; }
    }
}