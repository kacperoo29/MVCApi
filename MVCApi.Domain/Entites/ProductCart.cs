namespace MVCApi.Domain.Entites
{
    public class ProductCart : BaseEntity
    {
        private ProductCart()
        {
        }

        public ProductCart(Product product, ShoppingCart cart, int count)
        {
            ShoppingCart = cart;
            Product = product;
            Count = count;
        }

        public virtual ShoppingCart ShoppingCart { get; }
        public virtual Product Product { get; }
        public int Count { get; }
    }
}