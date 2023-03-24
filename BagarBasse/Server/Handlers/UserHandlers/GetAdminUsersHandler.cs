using BagarBasse.Server.Requests.UserRequests;
using BagarBasse.Server.Services.UserService;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace BagarBasse.Server.Handlers.UserHandlers;

[Authorize(Roles = "Admin")]
public class GetAdminUsersHandler :IRequestHandler<GetAdminUsersRequest, IResult>
{
    private readonly IUserService _userService;

    public GetAdminUsersHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IResult> Handle(GetAdminUsersRequest request, CancellationToken cancellationToken)
    {
        return await _userService.GetAdminUsers();
    }
}