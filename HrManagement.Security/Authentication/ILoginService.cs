using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.Authentication
{
    public interface ILoginService
    {
        Task<SignInResult> SignIn(string userName, string password);

        Task SignOutAsync();

        Task<int> GetAttemptAsync(string userName);

        Task<ApplicationUser?> GetUserAsync(string userName);

        bool IsValidTemporaryCredentials(string tempPassword, string tempPasswordHash);
    }
}
