using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.AuthRequests;

public class RegisterUserRequest : IHttpRequest
{
    public UserRegister User { get; set; }
}