using System;
using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class ShoppingCart : BaseEntity
    {
        protected ShoppingCart()
        {
            Products = new List<ProductCart>();
        }

        public virtual ICollection<ProductCart> Products { get; private set; }

        public static ShoppingCart Create()
        {
            return new ShoppingCart();
        }

        public void AddProduct(Product product, int count)
        {
            // TODO: Check if product can be added

            Products.Add(new ProductCart(product, this, count));
        }

        public void RemoveProduct(Guid productId)
        {
            foreach (var item in Products)
                if (item.Product.Id == productId)
                    Products.Remove(item);
        }

        public void Clear()
        {
            Products.Clear();
        }
    }
}