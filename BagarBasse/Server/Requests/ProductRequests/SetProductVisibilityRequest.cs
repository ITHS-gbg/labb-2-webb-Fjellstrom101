using Microsoft.AspNetCore.Mvc;

namespace BagarBasse.Server.Requests.ProductRequests;

public class SetProductVisibilityRequest: IHttpRequest
{
    [FromRoute]
    public int Id { get; set; }
    [FromBody]
    public bool Visible { get; set; }
}