using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.Authentication
{
    public interface ILoginService
    {
        Task<SignInResult> SignIn(string userName, string password);

        void SignOut();

        Task<int> GetAttemptAsync(string userName);

        Task<ApplicationUser?> GetUser(string userName);
    }
}
