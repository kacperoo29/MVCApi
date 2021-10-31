using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class ShoppingCart : BaseEntity
    {
        public virtual ICollection<ProductCart> Products { get; private set; }

        protected ShoppingCart()
            : base()
        {
            Products = new List<ProductCart>();
        }

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