namespace MVCApi.Domain.Entites
{
    public class ProductCart : BaseEntity
    {
        public virtual ShoppingCart ShoppingCart { get; private set; }
        public virtual Product Product { get; private set; }
        public int Count { get; private set; }

        private ProductCart() { }

        public ProductCart(Product product, ShoppingCart cart, int count)
            : base()
        {
            ShoppingCart = cart;
            Product = product;
            Count = count;
        }        
    }
}