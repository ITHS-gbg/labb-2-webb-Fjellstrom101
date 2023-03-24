using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.UserInfoRequests;

public class UpdateUserInfoRequest: IHttpRequest
{
    public UserInfo UserInfo { get; set; }
}