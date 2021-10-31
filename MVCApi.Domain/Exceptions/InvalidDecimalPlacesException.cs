using System;

namespace MVCApi.Domain.Exceptions
{
    public class InvalidDecimalPlacesException : Exception
    {
        public InvalidDecimalPlacesException(int decimalPlaces)
            : base($"Number of decimal places is {decimalPlaces} and should be between 0 and 6")
        {
            
        }
    }
}