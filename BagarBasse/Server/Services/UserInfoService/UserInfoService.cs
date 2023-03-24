using System.Net;
using BagarBasse.DataAccess;
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

    public async Task<IResult> GetUserInfo()
    {
        var userInfo = await GetUserInfoForCurrentUser();

        if (userInfo == null)
            return TypedResults.NoContent();

        return TypedResults.Ok(userInfo);
    }

    public async Task<IResult> AddUserInfo(UserInfo userInfo)
    {
        var dbUserInfo = await GetUserInfoForCurrentUser();

        if (dbUserInfo != null)
            return await UpdateUserInfo(userInfo);
        

        userInfo.UserId = _authService.GetUserId();
        await _storeUnitOfWork.UserInfoRepository.InsertAsync(userInfo);

        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok(userInfo);

    }
    public async Task<IResult> UpdateUserInfo(UserInfo userInfo)
    {
        var dbUserInfo = await GetUserInfoForCurrentUser();

        if (dbUserInfo == null)
            return await AddUserInfo(userInfo);
        

        dbUserInfo.FirstName = userInfo.FirstName;
        dbUserInfo.LastName = userInfo.LastName;
        dbUserInfo.Street = userInfo.Street;
        dbUserInfo.PostalCode = userInfo.PostalCode;
        dbUserInfo.City = userInfo.City;
        dbUserInfo.PhoneNumber = userInfo.PhoneNumber;

        await _storeUnitOfWork.SaveChangesAsync();
        return TypedResults.Ok(dbUserInfo);
    }

    private async Task<UserInfo?> GetUserInfoForCurrentUser()
    {
        var userId = _authService.GetUserId();
        return await _storeUnitOfWork.UserInfoRepository.GetByID(userId);
        
    }
}