using System;
using System.Threading.Tasks;
using MVCApi.Domain;

namespace MVCApi.Application
{
    public interface IUserService
    {
        Task<IApplicationUser> GetCurrentUser();
        Task<Guid> CreateUser(string email, string userName, string password);
        Task<Guid> SignInAsync(string email, string password, bool rememberMe);
        Task<Guid> SignOutAsync();
    }
}