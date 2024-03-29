﻿using BagarBasse.Server.Requests.UserInfoRequests;
using BagarBasse.Server.Services.UserInfoService;
using MediatR;

namespace BagarBasse.Server.Handlers.UserInfoHandlers;

public class AddUserInfoHandler : IRequestHandler<AddUserInfoRequest, IResult>
{
    private readonly IUserInfoService _userInfoService;

    public AddUserInfoHandler(IUserInfoService userInfoService)
    {
        _userInfoService = userInfoService;
    }

    public async Task<IResult> Handle(AddUserInfoRequest request, CancellationToken cancellationToken)
    {
        var response = await _userInfoService.AddUserInfoAsync(request.UserInfo);
        return response;
    }
}