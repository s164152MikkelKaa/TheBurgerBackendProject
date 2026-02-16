using Microsoft.AspNetCore.Identity;
using TheBurgerBackendProject.DTOs;

namespace TheBurgerBackendProject.Services
{
    public interface IAccountStateService
    {
        Task<(bool Success, string? ErrorMessage)> LoginUserAsync(UserLoginDTO loginInfo);
        Task<(bool Success, string? ErrorMessage)> LogoutUserAsync();
        Task<(bool Success, string? ErrorMessage)> RegisterUserAsync(UserNewDTO user);
    }

    public class AccountStateService : IAccountStateService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountStateService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(bool Success, string? ErrorMessage)> RegisterUserAsync(UserNewDTO user)
        {
            var registerUser = new IdentityUser { Email = user.Email, EmailConfirmed = true, UserName = user.UserName };
            var result = await _userManager.CreateAsync(registerUser, user.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(registerUser, isPersistent: false);
                return (true, null);
            }
            string theErrorDescription = "";
            foreach (var theError in result.Errors)
            {
                theErrorDescription += theError.Description + ", ";
            }
            return (false, theErrorDescription);
        }

        public async Task<(bool Success, string? ErrorMessage)> LoginUserAsync(UserLoginDTO loginInfo)
        {
            var (success, errorMessage, theUser) = await GetUserByEmailAsync(loginInfo.Email);
            if (!success)
            {
                return (success, errorMessage);
            }
            var result = await _signInManager.PasswordSignInAsync(theUser, loginInfo.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return (true, null);
            }
            return (false, "Can't sign in.");
        }

        private async Task<(bool Success, string? ErrorMessage, IdentityUser? theUser)> GetUserByEmailAsync(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            if (result == null)
            {
                return (false, "No matching e-mail", null);
            }
            return (true, null, result);
        }

        public async Task<(bool Success, string? ErrorMessage)> LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
            return (true, null);
        }
    }
}
