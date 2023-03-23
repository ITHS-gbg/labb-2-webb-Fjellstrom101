using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.AuthRequests;

public class LoginUserRequest : IHttpRequest
{
    public UserLogin User { get; set; }
}