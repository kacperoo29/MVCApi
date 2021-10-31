using System;

namespace MVCApi.Domain.Exceptions
{
    public class InvalidCurrencyCodeException : Exception
    {
        public InvalidCurrencyCodeException(string code)
            : base($"Currency code {code} is invalid")
        {
            
        }
    }
}