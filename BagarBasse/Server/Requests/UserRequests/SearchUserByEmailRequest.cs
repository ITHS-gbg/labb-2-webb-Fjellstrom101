namespace BagarBasse.Server.Requests.UserRequests;

public class SearchUserByEmailRequest : IHttpRequest
{
    public string Email { get; set; }
}