using System;

namespace MVCApi.Domain.Entites
{
    public class ProductCart
    {
        protected ProductCart()
        {
        }

        public ProductCart(Product product, ShoppingCart cart, int count)
        {
            ShoppingCart = cart;
            ShoppingCartId = cart.Id;
            Product = product;
            ProductId = product.Id;
            Count = count;
        }

        public virtual ShoppingCart ShoppingCart { get; private set; }
        public virtual Guid ShoppingCartId { get; private set; }
        public virtual Product Product { get; private set; }
        public virtual Guid ProductId { get; private set; }
        public int Count { get; private set; }

        public void SetCount(int count) {
            // TODO: Make sure enough is in stock
            Count = count;
        }
    }
}