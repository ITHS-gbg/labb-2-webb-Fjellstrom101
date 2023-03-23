using BagarBasse.Server.Requests.AuthRequests;
using BagarBasse.Server.Services.AuthService;
using BagarBasse.Shared.Models;
using MediatR;

namespace BagarBasse.Server.Handlers.AuthHandlers;

public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, IResult>
{
    private readonly IAuthService _authService;

    public RegisterUserHandler(IAuthService authService)
    {
        _authService = authService;
    }
    public async Task<IResult> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        return await _authService.Register(new User { Email = request.User.Email }, request.User.Password);
    }
}