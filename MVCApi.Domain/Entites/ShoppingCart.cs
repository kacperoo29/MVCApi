using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class ShoppingCart : BaseEntity
    {
        protected ShoppingCart()
        {
            Products = new List<ProductCart>();
        }

        public virtual ICollection<ProductCart> Products { get; }

        public static ShoppingCart Create()
        {
            return new ShoppingCart();
        }

        public void AddProduct(Product product, int count)
        {
            // TODO: Check if product can be added

            Products.Add(new ProductCart(product, this, count));
        }
    }
}