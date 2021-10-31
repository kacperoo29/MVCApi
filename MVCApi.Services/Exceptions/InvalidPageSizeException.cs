using System;

namespace MVCApi.Services.Exceptions
{
    public class InvalidPageSizeException : Exception
    {
        public InvalidPageSizeException(int actualSize)
            : base(
                $"Page size is {actualSize} and should be beetween {ServicesConstants.MinPageSize} and {ServicesConstants.MaxPageSize}")
        {
        }
    }
}