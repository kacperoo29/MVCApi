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

        protected Category(string name, Category parent)
            : this(name)
        {            
            ParentId = parent.Id;
            Parent = parent;
        }

        public string Name { get; private set; }
        public Guid? ParentId { get; private set; }
        public virtual Category Parent { get; private set; }
        public virtual ICollection<Category> Children { get; private set; }
        public virtual ICollection<Product> Products { get; private set; }

        public static Category Create(string name)
        {
            return new Category(name);
        }

        public static Category Create(string name, Category parent)
        {
            return new Category(name, parent);
        }
    }
}