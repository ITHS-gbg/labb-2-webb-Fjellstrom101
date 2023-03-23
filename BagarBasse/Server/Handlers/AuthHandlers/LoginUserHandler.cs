using BagarBasse.Server.Requests.AuthRequests;
using BagarBasse.Server.Services.AuthService;
using MediatR;

namespace BagarBasse.Server.Handlers.AuthHandlers;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, IResult>
{
    private readonly IAuthService _authService;

    public LoginUserHandler(IAuthService authService)
    {
        _authService = authService;
    }
    public async Task<IResult> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        return await _authService.Login(request.User.Email, request.User.Password);
    }
}