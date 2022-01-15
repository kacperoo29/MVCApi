using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MVCApi.Application.Commands
{
    public class SignOut : IRequest<Guid>
    {
        public class Handler : IRequestHandler<SignOut, Guid>
        {
            private readonly IUserService _userService;

            public Handler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Guid> Handle(SignOut request, CancellationToken cancellationToken)
            {
                return await _userService.SignOutAsync();
            }
        }
    }
}