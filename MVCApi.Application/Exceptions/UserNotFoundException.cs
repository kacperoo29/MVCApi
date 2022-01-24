using System;

namespace MVCApi.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string identifier)
            : base($"User with identifier {identifier} not found")
        {
            
        }
    }
}