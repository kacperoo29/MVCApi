using System;

namespace MVCApi.Domain.Entites
{
    public class CurrencyProduct
    {
        private CurrencyProduct()
        {
        }

        public CurrencyProduct(Product product, Currency currency, decimal value)
        {
            Product = product;
            ProductId = product.Id;
            Currency = currency;
            CurrencyId = currency.Id;
            Value = value;
        }

        public virtual Product Product { get; private set; }
        public virtual Guid ProductId { get; private set; }
        public virtual Currency Currency { get; private set; }
        public virtual Guid CurrencyId { get; private set; }
        public decimal Value { get; private set; }
    }
}