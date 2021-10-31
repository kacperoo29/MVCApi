using System.Collections.Generic;

namespace MVCApi.Application.DTOs
{
    public class CurrencyDTO
    {
        public string Code { get; private set; }
        public int DecimalPlaces { get; private set; }
        public decimal Value { get; private set; }
    }
}