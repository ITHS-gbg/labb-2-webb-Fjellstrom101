using BagarBasse.Server.Requests.AuthRequests;
using BagarBasse.Server.Services.AuthService;
using MediatR;

namespace BagarBasse.Server.Handlers.AuthHandlers;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, IResult>
{
    private readonly IAuthService _authService;

    public ChangePasswordHandler(IAuthService authService)
    {
        _authService = authService;
    }
    public async Task<IResult> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        return await _authService.ChangePasswordAsync(_authService.GetUserId(), request.NewPassword);
    }
}