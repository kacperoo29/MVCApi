using System;

namespace MVCApi.Domain.Exceptions
{
    public class InvalidEntityStateException : Exception
    {
        public InvalidEntityStateException(Type entityType, string state, string actionName)
            : base($"{entityType.ToString()} is in invalid state {state} for action {actionName}")
        {
            
        }
    }
}