using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MVCApi.Application.Commands
{
    public class CreateRole : IRequest<Guid>
    {
        public string RoleName { get; init; }

        public class Handler : IRequestHandler<CreateRole, Guid>
        {
            private readonly IUserService _userService;

            public Handler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Guid> Handle(CreateRole request, CancellationToken cancellationToken)
            {
                return await _userService.CreateRole(request.RoleName);
            }
        }
    }
}