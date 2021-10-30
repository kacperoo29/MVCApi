using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public ICollection<ProductCart> ShoppingCarts { get; private set; }
        public ICollection<CurrencyProduct> Prices { get; private set; }

        protected Product(string name, string description) 
        {
            ShoppingCarts = new List<ProductCart>();
            Prices = new List<CurrencyProduct>();
            Name = name;
            Description = description;
        }

        public static Product Create(string name, string description)
        {
            return new Product(name, description);
        }
        
    }
}