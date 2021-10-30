using System;
using System.Net;
using MVCApi.Domain.Entites;

namespace MVCApi.Domain
{
    public interface IApplicationUser
    {
        Guid Id { get; }
        IDomainUser DomainUser { get; }
    }
}