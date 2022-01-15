using System;
using Microsoft.AspNetCore.Identity;
using MVCApi.Application;
using MVCApi.Domain;

namespace MVCApi.Services
{
    public class ApplicationUser : IdentityUser<Guid>, IApplicationUser
    {
        public virtual IDomainUser DomainUser { get; set; }
    }
}