using System;

namespace MVCApi.Domain
{
    public interface IDomainUser
    {
        Guid Id { get; }
        Guid ApplicationUserId { get; }
        IApplicationUser ApplicationUser { get; }
    }
}