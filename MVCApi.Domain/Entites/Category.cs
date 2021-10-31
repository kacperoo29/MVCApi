using System;
using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class Category : BaseEntity
    {
        protected Category(string name)
        {
            Name = name;
            Children = new List<Category>();
            Products = new List<Product>();
        }

        public string Name { get; }
        public Guid? ParentId { get; private set; }
        public virtual Category Parent { get; private set; }
        public virtual ICollection<Category> Children { get; }
        public virtual ICollection<Product> Products { get; }

        public static Category Create(string name)
        {
            return new Category(name);
        }
    }
}