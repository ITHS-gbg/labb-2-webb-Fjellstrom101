using Microsoft.AspNetCore.Mvc;

namespace BagarBasse.Server.Requests.AuthRequests;

public class ChangePasswordRequest : IHttpRequest
{
    [FromBody]
    public string NewPassword { get; set; }
}