using BagarBasse.Server.Requests.UserInfoRequests;
using BagarBasse.Server.Services.UserInfoService;
using MediatR;

namespace BagarBasse.Server.Handlers.UserInfoHandlers;

public class GetUserInfoHandler : IRequestHandler<GetUserInfoRequest, IResult>
{
    private readonly IUserInfoService _userInfo;

    public GetUserInfoHandler(IUserInfoService userInfo)
    {
        _userInfo = userInfo;
    }
    public async Task<IResult> Handle(GetUserInfoRequest request, CancellationToken cancellationToken)
    {
        var response = await _userInfo.GetUserInfoAsync();
        return response;
    }
}