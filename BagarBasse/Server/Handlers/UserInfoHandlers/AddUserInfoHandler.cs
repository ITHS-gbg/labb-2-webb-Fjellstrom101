using BagarBasse.Server.Requests.UserInfoRequests;
using BagarBasse.Server.Services.UserInfoService;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace BagarBasse.Server.Handlers.UserInfoHandlers;

[Authorize(Roles = "Admin")]
public class AddUserInfoHandler : IRequestHandler<AddUserInfoRequest, IResult>
{
    private readonly IUserInfoService _userInfoService;

    public AddUserInfoHandler(IUserInfoService userInfoService)
    {
        _userInfoService = userInfoService;
    }

    public async Task<IResult> Handle(AddUserInfoRequest request, CancellationToken cancellationToken)
    {
        var response = await _userInfoService.AddUserInfo(request.UserInfo);
        return response;
    }
}