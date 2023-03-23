namespace BagarBasse.Server.Requests.AuthRequests;

public class ChangePasswordRequest : IHttpRequest
{
    public string NewPassword { get; set; }
}