using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MVCApi.Application;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<IApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task<IApplicationUser> CreateUser(IDomainUser domainUser, string userName, string password)
        {
            var newUser = new ApplicationUser { UserName = userName, DomainUser = domainUser, Id = domainUser.Id };
            var errors = await _userManager.CreateAsync(newUser, password);

            return newUser;
        }
    }
}