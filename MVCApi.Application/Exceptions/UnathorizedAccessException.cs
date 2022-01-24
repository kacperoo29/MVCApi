using System;

namespace MVCApi.Application.Exceptions
{
    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException()
            : base("Current user doesn't have access to this asset")
        {
            
        }
    }
}