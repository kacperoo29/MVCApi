using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MVCApi.Domain.Entites
{
    public class ShoppingCart : BaseEntity
    {
        public Customer Owner { get; private set; }
        public List<Product> Products { get; private set; }

        public ShoppingCart() {}

        protected ShoppingCart(Customer owner)
        {
            Owner = owner;
        }

        public static ShoppingCart Create(Customer owner) {
            return new ShoppingCart(owner);
        }

        public void AddProduct(Product product) {
            // TODO: Check if product can be added

            Products.Add(product);
        }

    }
}