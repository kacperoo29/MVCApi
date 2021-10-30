using System;
using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public Guid? ParentId { get; private set; }
        public Category Parent { get; private set; }
        public ICollection<Category> Children { get; private set; }
        public ICollection<Product> Products { get; private set; }

        protected Category(string name)
            : base()
        {
            Name = name;
            Children = new List<Category>();
            Products = new List<Product>();
        }

        public static Category Create(string name)
        {
            return new Category(name);
        }
    }
}