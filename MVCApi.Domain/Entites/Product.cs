using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class Product : BaseEntity
    {
        protected Product(string name, string description)
        {
            ShoppingCarts = new List<ProductCart>();
            Prices = new List<CurrencyProduct>();
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
        public virtual Category Category { get; private set; }
        public virtual ICollection<ProductCart> ShoppingCarts { get; }
        public virtual ICollection<CurrencyProduct> Prices { get; }

        public static Product Create(string name, string description)
        {
            return new Product(name, description);
        }
    }
}