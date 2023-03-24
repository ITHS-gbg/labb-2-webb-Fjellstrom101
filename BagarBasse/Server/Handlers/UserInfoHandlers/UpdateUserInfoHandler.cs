using BagarBasse.Server.Requests.UserInfoRequests;
using BagarBasse.Server.Services.UserInfoService;
using MediatR;

namespace BagarBasse.Server.Handlers.UserInfoHandlers;

public class UpdateUserInfoHandler : IRequestHandler<UpdateUserInfoRequest, IResult>
{
    private readonly IUserInfoService _userInfoService;

    public UpdateUserInfoHandler(IUserInfoService userInfoService)
    {
        _userInfoService = userInfoService;
    }
    public async Task<IResult> Handle(UpdateUserInfoRequest request, CancellationToken cancellationToken)
    {
        var response = await _userInfoService.UpdateUserInfoAsync(request.UserInfo);
        return response;
    }
}