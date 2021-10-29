using System;
using System.Threading.Tasks;
using MVCApi.Application;
using MVCApi.Domain;

namespace MVCApi.Application
{
    public interface IUserService
    {
        Task<IApplicationUser> GetCurrentUser();
        Task<IApplicationUser> CreateUser(IDomainUser domainUser, string userName, string password);
    }
}