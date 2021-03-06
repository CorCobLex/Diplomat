using Application.Contracts.Authorization;
using Application.Dto;
using Application.Dto.Authorization;
using Application.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthenticationService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<AuthenticationData> AuthenticateAsync(string userName, string password)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new ApiException("Неверный Логин или Пароль");

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(user, password);
            if (passwordIsCorrect == false)
                throw new ApiException("Неверный Логин или Пароль");

            return new AuthenticationData(user.Id);
        }
        catch (Exception ex)
        {
            throw new ApiException(ex.Message);
        }
        
    }
}