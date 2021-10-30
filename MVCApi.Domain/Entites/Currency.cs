using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class Currency : BaseEntity
    {
        public string Code { get; private set; }
        public int DecimalPlaces { get; private set; }
        public ICollection<CurrencyProduct> Products { get; private set; }
    }
}