﻿using BagarBasse.Server.Requests.UserRequests;
using BagarBasse.Server.Services.UserService;
using MediatR;

namespace BagarBasse.Server.Handlers.UserHandlers;

public class GetAdminUsersHandler :IRequestHandler<GetAdminUsersRequest, IResult>
{
    private readonly IUserService _userService;

    public GetAdminUsersHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IResult> Handle(GetAdminUsersRequest request, CancellationToken cancellationToken)
    {
        return await _userService.GetAdminUsersAsync();
    }
}