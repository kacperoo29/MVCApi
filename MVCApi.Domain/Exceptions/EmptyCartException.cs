using System;

namespace MVCApi.Domain.Exceptions
{
    public class EmptyCartException : Exception
    {
        public EmptyCartException(Guid cartId)
            : base($"Shopping cart with id {cartId} is empty and cannot be used to create an order")
        {
            
        }
    }
}