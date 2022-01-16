using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Application.Dto;

namespace MVCApi.Application.Commands
{
    public class SignIn : IRequest<AuthResponseDto>
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public bool RememberMe { get; init; }

        public class Handler : IRequestHandler<SignIn, AuthResponseDto>
        {
            private readonly IUserService _userService;

            public Handler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<AuthResponseDto> Handle(SignIn request, CancellationToken cancellationToken)
            {
                return await _userService.SignInAsync(request.Email, request.Password, request.RememberMe);
            }
        }
    }
}