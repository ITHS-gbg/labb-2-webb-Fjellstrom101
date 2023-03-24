using BagarBasse.DataAccess;
using BagarBasse.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.UserService;

public class UserService : IUserService
{
    private readonly StoreUnitOfWork _storeUnitOfWork;

    public UserService(StoreUnitOfWork storeUnitOfWork)
    {
        _storeUnitOfWork = storeUnitOfWork;
    }
    public async Task<IResult> GetAdminUsers()
    {
        var result = new List<UserDto>();

        await _storeUnitOfWork.UserRepository.Get()
            .Include(u => u.UserInfo)
            .ForEachAsync(u => result.Add(new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                Role = u.Role,
                UserInfo = u.UserInfo,
                DateCreated = u.DateCreated
            }));

        return TypedResults.Ok(result);
    }
}