namespace MVCApi.Domain.Values
{
    public class Money 
    {
        public CurrencyDetails Currency { get; private set; }
        public decimal Value { get; private set; }
    }
}