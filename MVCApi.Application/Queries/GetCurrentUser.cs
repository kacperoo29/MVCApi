using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MVCApi.Application.Dto;
using MVCApi.Domain;

namespace MVCApi.Application.Queries
{
    public class GetCurrentUser : IRequest<ApplicationUserDto>
    {
        public class Handler : IRequestHandler<GetCurrentUser, ApplicationUserDto>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public Handler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<ApplicationUserDto> Handle(GetCurrentUser request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IApplicationUser, ApplicationUserDto>(await _userService.GetCurrentUser());
            }
        }
    }
}