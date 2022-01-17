using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MVCApi.Application;
using MVCApi.Application.Dto;
using MVCApi.Application.Exceptions;
using MVCApi.Domain;

namespace MVCApi.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtHandler _jwtHandler;

        public UserService(IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            JwtHandler jwtHandler)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtHandler = jwtHandler;
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

        public async Task<Guid> LinkDomainUser<T>(Guid id, T user) where T : IDomainUser
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());
            appUser.DomainUser = user;
            await _userManager.UpdateAsync(appUser);

            return appUser.Id;
        }

        public async Task<AuthResponseDto> SignInAsync(string email, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                throw new UserNotFoundException(email);

            var result = await _userManager.CheckPasswordAsync(user, password);
            //var result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, lockoutOnFailure: false);

            if (!result)
                return new AuthResponseDto { ErrorMessage = "Invalid authentication" };

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthResponseDto { IsAuthSuccessful = true, Token = token };
        }
    }
}