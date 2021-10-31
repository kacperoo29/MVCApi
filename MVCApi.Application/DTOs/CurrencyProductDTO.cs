using System.Collections.Generic;

namespace MVCApi.Application.DTOs
{
    public class CurrencyProductDTO
    {
        public CurrencyDTO Currency { get; private set; }
        public decimal Value { get; private set; }
    }
}