using System.Collections.Generic;

namespace MVCApi.Application.DTOs
{
    public class CategoryDTO
    {
        public string Name { get; private set; }
        public virtual CategoryDTO Parent { get; private set; }
        public virtual ICollection<CategoryDTO> Children { get; private set; }
        public virtual ICollection<ProductDTO> Products { get; private set; }
    }
}