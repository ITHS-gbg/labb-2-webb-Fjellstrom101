using BagarBasse.Server.Requests.UserRequests;
using BagarBasse.Server.Services.UserService;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BagarBasse.Server.Handlers.UserHandlers;

public class SearchUserByEmailHandler : IRequestHandler<SearchUserByEmailRequest, IResult>
{
    private readonly IUserService _userService;

    public SearchUserByEmailHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IResult> Handle(SearchUserByEmailRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.SearchUserByEmailAsync(request.Email);
        return response;
    }
}