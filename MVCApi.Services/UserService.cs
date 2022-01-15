using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MVCApi.Application;
using MVCApi.Application.Exceptions;
using MVCApi.Domain;

namespace MVCApi.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task<Guid> CreateUser(string email, string userName, string password)
        {
            var newUser = new ApplicationUser { UserName = userName, Email = email };
            var result = await _userManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
                throw new RegistrationException(result.Errors.Select(x => x.Description));

            return newUser.Id;
        }

        public async Task<Guid> LinkDomainUser(Guid id, IDomainUser user)
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());
            appUser.DomainUser = user;
            await _userManager.UpdateAsync(appUser);

            return appUser.Id;
        }

        public async Task<Guid> SignInAsync(string email, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                throw new UserNotFoundException(email);

            var result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, lockoutOnFailure: false);

            if (!result.Succeeded)
                throw new SignInException(email);

            return user.Id;
        }

        public async Task<Guid> SignOutAsync()
        {
            var user = await GetCurrentUser();
            await _signInManager.SignOutAsync();

            return user.Id;
        }
    }
}