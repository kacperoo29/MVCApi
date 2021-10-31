namespace MVCApi.Domain.Entites
{
    public class CurrencyProduct : BaseEntity
    {
        public virtual Product Product { get; private set; }
        public virtual Currency Currency { get; private set; }
        public decimal Value { get; private set; }

        private CurrencyProduct() { }

        public CurrencyProduct(Product product, Currency currency, decimal value)
            : base()
        {
            Product = product;
            Currency = currency;
            Value = value;
        }
    }
}