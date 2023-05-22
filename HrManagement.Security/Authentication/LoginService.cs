using HrManagement.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.Authentication
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> SignIn(string userName, string password)
        {
            return await _signInManager.PasswordSignInAsync(userName,
                    password, isPersistent: false, lockoutOnFailure: true);
        }

        public async Task SignOutAsync() => await _signInManager.SignOutAsync();

        public async Task<int> GetAttemptAsync(string userName)
        {
            int attempt = 0;

            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
                attempt = await _userManager.GetAccessFailedCountAsync(user);

            return attempt;
        }
       

        public async Task<ApplicationUser?> GetUserAsync(string userName) =>
            await _userManager.FindByNameAsync(userName);

        public bool IsValidTemporaryCredentials(string tempPassword, string tempPasswordHash)
        {
            var sha256 = Encrypt.GenerateSHA256Hash(tempPassword);
            return tempPasswordHash.Equals(sha256);
        }
    }
}
