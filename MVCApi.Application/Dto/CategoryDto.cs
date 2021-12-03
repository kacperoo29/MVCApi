using System;
using System.Collections.Generic;

namespace MVCApi.Application.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CategoryDto> Children { get; set; }
    }
}