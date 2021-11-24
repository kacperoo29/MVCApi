using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class Product : BaseEntity
    {
        protected Product()
        {

        }

        protected Product(string name, string description, string image, decimal price, Currency currency)
        {
            ShoppingCarts = new List<ProductCart>();
            Prices = new List<CurrencyProduct>();
            Name = name;
            Description = description;
            Image = image;
            Prices.Add(new CurrencyProduct(this, currency, price));
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public virtual ICollection<Category> Categories { get; private set; }
        public virtual ICollection<ProductCart> ShoppingCarts { get; private set; }
        public virtual ICollection<CurrencyProduct> Prices { get; private set; }

        public static Product Create(string name, string description, string image, decimal price, Currency currency)
        {
            return new Product(name, description, image, price, currency);
        }

        public void AddConversion(CurrencyProduct cp)
        {
            Prices.Add(cp);
        }
    }
}