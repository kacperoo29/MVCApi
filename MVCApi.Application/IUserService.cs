using System;
using System.Threading.Tasks;
using MVCApi.Application.Dto;
using MVCApi.Domain;

namespace MVCApi.Application
{
    public interface IUserService
    {
        Task<IApplicationUser> GetCurrentUser();
        Task<Guid> CreateUser(string email, string userName, string password);
        Task<AuthResponseDto> SignInAsync(string email, string password, bool rememberMe);
    }
}