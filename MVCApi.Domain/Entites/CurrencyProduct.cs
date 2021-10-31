namespace MVCApi.Domain.Entites
{
    public class CurrencyProduct : BaseEntity
    {
        private CurrencyProduct()
        {
        }

        public CurrencyProduct(Product product, Currency currency, decimal value)
        {
            Product = product;
            Currency = currency;
            Value = value;
        }

        public virtual Product Product { get; }
        public virtual Currency Currency { get; }
        public decimal Value { get; }
    }
}