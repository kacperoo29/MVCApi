using System;

namespace MVCApi.Application.Dto
{
    public class CurrencyDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int DecimalPlaces { get; set; }
    }
}