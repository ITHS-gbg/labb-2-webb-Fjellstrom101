using BagarBasse.Server.Services.AuthService;
using BagarBasse.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.UserInfoService;

public class UserInfoService : IUserInfoService
{
    private readonly StoreUnitOfWork _storeUnitOfWork;
    private readonly IAuthService _authService;

    public UserInfoService(StoreUnitOfWork storeUnitOfWork, IAuthService authService)
    {
        _storeUnitOfWork = storeUnitOfWork;
        _authService = authService;
    }

    public async Task<IResult> GetUserInfoAsync()
    {
        var userInfo = await GetUserInfoForCurrentUserAsync();

        if (userInfo == null)
            return TypedResults.NoContent();

        return TypedResults.Ok(userInfo);
    }

    public async Task<IResult> AddUserInfoAsync(UserInfo userInfo)
    {
        var dbUserInfo = await GetUserInfoForCurrentUserAsync();

        if (dbUserInfo != null)
            return await UpdateUserInfoAsync(userInfo);
        

        userInfo.UserId = _authService.GetUserId();
        await _storeUnitOfWork.UserInfoRepository.InsertAsync(userInfo);

        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok(userInfo);

    }
    public async Task<IResult> UpdateUserInfoAsync(UserInfo userInfo)
    {
        var dbUserInfo = await GetUserInfoForCurrentUserAsync();

        if (dbUserInfo == null)
            return await AddUserInfoAsync(userInfo);
        

        dbUserInfo.FirstName = userInfo.FirstName;
        dbUserInfo.LastName = userInfo.LastName;
        dbUserInfo.Street = userInfo.Street;
        dbUserInfo.PostalCode = userInfo.PostalCode;
        dbUserInfo.City = userInfo.City;
        dbUserInfo.PhoneNumber = userInfo.PhoneNumber;

        await _storeUnitOfWork.SaveChangesAsync();
        return TypedResults.Ok(dbUserInfo);
    }

    private async Task<UserInfo?> GetUserInfoForCurrentUserAsync()
    {
        var userId = _authService.GetUserId();
        return await _storeUnitOfWork.UserInfoRepository.Get().FirstOrDefaultAsync(ui => ui.UserId == userId);
        
    }
}