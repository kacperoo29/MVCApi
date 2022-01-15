using System;
using MVCApi.Domain;

namespace MVCApi.Application
{
    public interface IApplicationUser
    {
        Guid Id { get; }
        IDomainUser DomainUser { get; }
    }
}