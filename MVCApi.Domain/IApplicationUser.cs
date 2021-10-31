using System;

namespace MVCApi.Domain
{
    public interface IApplicationUser
    {
        Guid Id { get; }
        IDomainUser DomainUser { get; }
    }
}