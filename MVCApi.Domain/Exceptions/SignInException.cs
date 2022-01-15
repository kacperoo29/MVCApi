using System;
using System.Collections.Generic;

namespace MVCApi.Application.Exceptions
{
    public class SignInException : Exception
    {
        public SignInException(string email)
            : base($"User sign in failed for user with email {email}")
        {

        }
    }
}