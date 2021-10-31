using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MVCApi.Application.Commands
{
    public class CreateUser : IRequest<Guid>
    {
        public string Email { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }

        public class Handler : IRequestHandler<CreateUser, Guid>
        {
            private readonly IUserService _userService;

            public Handler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Guid> Handle(CreateUser request, CancellationToken cancellationToken)
            {
                var user = await _userService.CreateUser(request.Email, request.UserName, request.Password);

                return user.Id;
            }
        }
    }
}