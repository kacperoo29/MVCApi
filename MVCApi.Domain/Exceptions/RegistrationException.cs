using System;
using System.Collections.Generic;

namespace MVCApi.Application.Exceptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException(IEnumerable<string> message)
            : base($"User registration failed with errors: {String.Join("\n", message)}")
        {

        }
    }
}