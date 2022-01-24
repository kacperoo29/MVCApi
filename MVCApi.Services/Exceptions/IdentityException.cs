using System;
using System.Collections.Generic;

namespace MVCApi.Services.Exceptions
{
    public class IdentityException : Exception
    {
        public IdentityException(IEnumerable<string> errors)
            : base($"Identity failed with errors: {String.Join('\n', errors)}")
        {

        }
    }
}