using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.UserInfoRequests;

public class AddUserInfoRequest : IHttpRequest
{
    public UserInfo UserInfo { get; set; }
}