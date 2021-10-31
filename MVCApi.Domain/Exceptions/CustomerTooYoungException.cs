using System;
using MVCApi.Domain.Consts;

namespace MVCApi.Domain.Exceptions
{
    public class CustomerTooYoungException : Exception
    {
        public CustomerTooYoungException()
            : base($"Customer should be atleast {EShopConsts.MinCustomerAge} years old")
        {
            
        }
    }
}