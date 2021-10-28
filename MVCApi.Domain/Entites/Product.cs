using System.Collections.Generic;
using System.Dynamic;

namespace MVCApi.Domain.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public List<ShoppingCart> Carts { get; private set; }

        public Product(string Name) {
            this.Name = Name;
            Carts = new List<ShoppingCart>();
        }

        public static Product Create(string Name) {
            return new Product(Name);
        }
        
    }
}