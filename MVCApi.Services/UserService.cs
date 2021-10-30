using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MVCApi.Application;
using MVCApi.Domain;

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

        public async Task<IApplicationUser> CreateUser(string email, string userName, string password)
        {
            var newUser = new ApplicationUser { UserName = userName, Email = email };
            var errors = await _userManager.CreateAsync(newUser, password);
            
            return newUser;
        }

        public async Task<Guid> LinkDomainUser(Guid id, IDomainUser user)
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());
            appUser.DomainUser = user;
            await _userManager.UpdateAsync(appUser);

            return appUser.Id;
        }
    }
}