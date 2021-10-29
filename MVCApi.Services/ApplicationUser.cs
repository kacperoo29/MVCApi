using System;
using Microsoft.AspNetCore.Identity;
using MVCApi.Application;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Services
{
    public class ApplicationUser : IdentityUser<Guid>, IApplicationUser
    {
        public IDomainUser DomainUser { get; private set; }
    }
}